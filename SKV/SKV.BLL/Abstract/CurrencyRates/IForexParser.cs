using System.Collections.Generic;

using SKV.ML.Concrete.Model.CurrencyModel;

namespace SKV.BLL.Abstract.CurrencyRates
{
    public interface IForexParser
    {
        IEnumerable<CurrencyRate> ParseOil();

        IEnumerable<CurrencyRate> ParseEuroToUsd();

        IEnumerable<CurrencyRate> ParseEuroUsdRub();

        IEnumerable<CurrencyRate> ParseOtherCurrencies();
    }
}
