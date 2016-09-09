using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.CurrencyModel
{
    public interface ICurrencyRateData<TKey> : IEntity<TKey>, ICloneableFrom<ICurrencyRateData<TKey>>
    {
        int Code { get; set; }

        int Ammount { get; set; }

        string Ticker { get; set; }
    }
}
