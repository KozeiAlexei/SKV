using System;
using System.Linq;
using System.Timers;
using System.Collections.Generic;

using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CurrencyModel;

using SKV.BLL.Abstract.CurrencyRates;

using Ninject;

namespace SKV.BLL.CurrencyRates
{
    public class CurrencyRateManager : ICurrencyRateManager
    {
        private class SuitableRates
        {
            public bool IsFounded { get; set; }

            public IEnumerable<CurrencyRate> Rates { get; set; }
        }

        private object sync_context = new object();

        private Timer timer = default(Timer);

        private IDbManager db_manager = DALDependencyResolver.Kernel.Get<IDbManager>();
        private IEnumerable<CurrencyRate> rates = default(IEnumerable<CurrencyRate>);

        private Func<IEnumerable<CurrencyRate>> strategy = default(Func<IEnumerable<CurrencyRate>>);

        private static Currency usd_currency = default(Currency);
        private static Currency rub_currency = default(Currency);
        private static Currency eur_currency = default(Currency);

        public CurrencyRateManager(Func<IEnumerable<CurrencyRate>> strategy)
        {
            UpdateRates();
            timer = Tools.CreatePeriodicProcess(UpdateRates, db_manager.SystemSettings.GetSystemSettings().RatesUpdatePeriod);

            this.strategy = strategy;

            usd_currency = db_manager.Currencies.GetCurrencyByShortName(StaticData.USDTicker);
            rub_currency = db_manager.Currencies.GetCurrencyByShortName(StaticData.RUBTicker);
            eur_currency = db_manager.Currencies.GetCurrencyByShortName(StaticData.EURTicker);
        }

        private void UpdateRates(object sender = null, ElapsedEventArgs e = null)
        {
            lock (sync_context)
            {
                rates = strategy();
            }
        }

        public decimal GetDirectRate(Currency client_currency, Currency bank_currency, decimal? sum = null)
        {
            if (bank_currency.ShortName != client_currency.ShortName)
            {
                var suitable_rates = FindSuitableRates(client_currency, bank_currency);

                if (!suitable_rates.Rates.Any())
                    return CalculateCrossRate(bank_currency, client_currency);

                if (suitable_rates.IsFounded)
                    return suitable_rates.Rates.Last().Purchase;
                return Tools.Inverse(suitable_rates.Rates.Last().Sale);
            }
            return 1.0M;
        }

        public decimal GetDisplayRate(Currency client_currency, Currency bank_currency, decimal rate)
        {
            var rule = db_manager.CurrencyExchangeRules.GetCurrencyExchangeRule(client_currency.Id, bank_currency.Id);
            if(rule != null)
            {
                if (rule.DisplayDirectRate)
                    return rate;
                return Tools.Inverse(rate);
            }
            return rate;
        }

        private decimal CalculateCrossRate(Currency bank_currency, Currency client_currency, decimal? sum = null)
        {
            if (IsExistRate(client_currency, usd_currency))
                return GetDirectRate(usd_currency, client_currency, sum) * GetDirectRate(bank_currency, usd_currency, sum);
            else if (IsExistRate(client_currency, rub_currency))
                return GetDirectRate(rub_currency, client_currency, sum) * GetDirectRate(bank_currency, rub_currency, sum);
            else if (IsExistRate(client_currency, eur_currency))
                return GetDirectRate(eur_currency, client_currency, sum) * GetDirectRate(bank_currency, eur_currency, sum);
            else
                throw new InvalidOperationException();
        }

        private bool CheckTicker(string ticker, string curr_in, string curr_out, bool is_multi_checking)
        {
            var parts = ticker.Split('/');

            if(is_multi_checking)
                return (curr_in.StartsWith(parts[0]) && curr_out.StartsWith(parts[1])) || (curr_in.StartsWith(parts[1]) && curr_out.StartsWith(parts[0]));
            return (curr_in.StartsWith(parts[0]) && curr_out.StartsWith(parts[1]));
        }

        private bool IsExistRate(Currency curr_in, Currency curr_out) => rates.Where(r => CheckTicker(r.Ticker, curr_in.ShortName, curr_out.ShortName, true)).Any();

        private SuitableRates FindSuitableRates(Currency client_currency, Currency bank_currency)
        {
            var suitable_rates = rates.Where(r => CheckTicker(r.Ticker, client_currency.ShortName, bank_currency.ShortName, false));

            if (suitable_rates.Any())
                return new SuitableRates() { IsFounded = true, Rates = suitable_rates };
            return new SuitableRates() { IsFounded = false, Rates = rates.Where(r => CheckTicker(r.Ticker, client_currency.ShortName, bank_currency.ShortName, true)) };
        }
    }
}
