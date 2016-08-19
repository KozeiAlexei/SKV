using SKV.BLL.Abstract.CurrencyRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKV.DAL.Concrete.Model.CurrencyModel;
using Ninject;
using System.Timers;
using SKV.DAL.Abstract.Database;
using SKV.DAL;

namespace SKV.BLL.CurrencyRates
{
    public class ForexRatesProvider : IRatesProvider, IDisposable
    {
        private Timer timer = default(Timer);

        private IDbManager db_manager = DALDependencyResolver.Kernel.Get<IDbManager>();
        private IForexParser parser = BLLDependencyResolver.Kernel.Get<IForexParser>();
        private IEnumerable<CurrencyRate> rates = default(IEnumerable<CurrencyRate>);

        public ForexRatesProvider()
        {
            UpdateRates();
            timer = Tools.CreatePeriodicProcess(UpdateRates, db_manager.SystemSettings.GetSystemSettings().RatesUpdatePeriod);
        }

        private void UpdateRates(object sender = null, ElapsedEventArgs e = null) =>
            rates = parser.ParseEuroUsdRub().Union(parser.ParseOtherCurrencies());

        public void Dispose() => timer.Stop();

        public decimal GetRate(Currency client_currency, Currency bank_currency)
        {
            if (bank_currency.ShortName != client_currency.ShortName)
            {
                var suitable_rates = CurrencyRateHelper.FindSuitableRates(rates, client_currency, bank_currency);

                if (!suitable_rates.Rates.Any())
                    return CurrencyRateHelper.CalculateCrossRate(bank_currency, client_currency);

                if (suitable_rates.IsFounded)
                    return suitable_rates.Rates.Last().Purchase;
                return Tools.Inverse(suitable_rates.Rates.Last().Sale);
            }
            return 1.0M;
        }

        public IEnumerable<CurrencyRate> GetRateList() => parser.ParseOil().Union(parser.ParseEuroUsdRub())
                                                                           .Union(parser.ParseEuroToUsd());
    }
}
