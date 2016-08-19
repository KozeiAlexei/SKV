using System.Collections.Generic;

using SKV.DAL.Concrete.Model.CurrencyModel;

namespace SKV.BLL.Abstract.CurrencyRates
{
    public interface IRatesProvider
    {
        CurrencyRate GetRate(Currency client_currency, Currency bank_currency);

        IEnumerable<CurrencyRate> GetRateList();
    }
}
