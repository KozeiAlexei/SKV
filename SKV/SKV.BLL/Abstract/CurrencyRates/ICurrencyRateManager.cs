using SKV.DAL.Concrete.Model.CurrencyModel;

namespace SKV.BLL.Abstract.CurrencyRates
{
    public interface ICurrencyRateManager
    {
        decimal GetDirectRate(Currency client_currency, Currency bank_currency, decimal? sum = null);

        decimal GetDisplayRate(Currency client_currency, Currency bank_currency, decimal rate);
    }
}
