using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CurrencyModel
{
    public interface ICurrencyRateData<TKey> : IEntity<TKey>, ICloneableFrom<ICurrencyRateData<TKey>>
    {
        int Code { get; set; }

        int Ammount { get; set; }

        string Ticker { get; set; }
    }
}
