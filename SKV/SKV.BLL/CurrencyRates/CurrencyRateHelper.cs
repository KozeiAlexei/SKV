using Ninject;
using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CurrencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.CurrencyRates
{
    public class SuitableRates
    {
        public bool IsFounded { get; set; }

        public IEnumerable<CurrencyRate> Rates { get; set; }
    }

    public static class CurrencyRateHelper
    {
        private static Currency usd_currency = default(Currency);
        private static Currency rub_currency = default(Currency);
        private static Currency eur_currency = default(Currency);

        static CurrencyRateHelper()
        {
            var db_manager = DALDependencyResolver.Kernel.Get<IDbManager>();

            usd_currency = db_manager.Currencies.GetCurrencyByShortName(StaticData.USDTicker);
            rub_currency = db_manager.Currencies.GetCurrencyByShortName(StaticData.RUBTicker);
            eur_currency = db_manager.Currencies.GetCurrencyByShortName(StaticData.EURTicker);
        }

        public static SuitableRates FindSuitableRates(IEnumerable<CurrencyRate> source, Currency client_currency, Currency bank_currency)
        {
            var rates = source.Where(r => CheckSingleTicker(r.Ticker, client_currency.ShortName, bank_currency.ShortName));

            if (rates.Any())
                return new SuitableRates() { IsFounded = true, Rates = rates };
            return new SuitableRates() { IsFounded = false, Rates = source.Where(r => CheckMultiTicker(r.Ticker, client_currency.ShortName, bank_currency.ShortName)) };
        }

        public static decimal CalculateCrossRate(Currency bank_currency, Currency client_currency, Func<Currency, Currency, decimal> rec_callback, IEnumerable<CurrencyRate> rates)
        {
            if (IsExistRate(rates, client_currency, usd_currency))
                return rec_callback(usd_currency, client_currency) * rec_callback(bank_currency, usd_currency);
            else if (IsExistRate(rates, client_currency, rub_currency))
                return rec_callback(rub_currency, client_currency) * rec_callback(bank_currency, rub_currency);
            else if (IsExistRate(rates, client_currency, eur_currency))
                return rec_callback(eur_currency, client_currency) * rec_callback(bank_currency, eur_currency);
            else
                throw new InvalidOperationException();
        }

        public static float CalculateCrossTotalRate(Currency bank_currency, Currency client_currency, float sum)
        {
            var usd = currency_manager.GetCurrencyByShortName("USD");
            var rub = currency_manager.GetCurrencyByShortName("RUB");
            var eur = currency_manager.GetCurrencyByShortName("EUR");

            if (IsExistRate(current_total_rates, client_currency, usd))
                return GetTotalRate(usd, client_currency, sum) * GetTotalRate(bank_currency, usd, sum);
            else if (IsExistRate(current_total_rates, client_currency, rub))
                return GetTotalRate(rub, client_currency, sum) * GetTotalRate(bank_currency, rub, sum);
            else if (IsExistRate(current_total_rates, client_currency, eur))
                return GetTotalRate(eur, client_currency, sum) * GetTotalRate(bank_currency, eur, sum);
            else
                throw new InvalidOperationException();
        }

        public static bool CheckSingleTicker(string ticker, string curr_in, string curr_out)
        {
            var parts = ticker.Split('/');

            return (curr_in.StartsWith(parts[0]) && curr_out.StartsWith(parts[1]));
        }

        public static bool CheckMultiTicker(string ticker, string curr_in, string curr_out)
        {
            var parts = ticker.Split('/');

            return (curr_in.StartsWith(parts[0]) && curr_out.StartsWith(parts[1])) || (curr_in.StartsWith(parts[1]) && curr_out.StartsWith(parts[0]));
        }

        public static bool IsExistRate(IEnumerable<CurrencyRate> rates, Currency curr_in, Currency curr_out) => rates.Where(r => CheckMultiTicker(r.Ticker, curr_in.ShortName, curr_out.ShortName)).Any();

    }
}
