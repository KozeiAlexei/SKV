using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CurrencyModel
{
    public interface ICurrencyExchangeRule<TKey, TCurrencyKey> : IEntity<TKey>, ICloneableFrom<ICurrencyExchangeRule<TKey, TCurrencyKey>>
    {
        TCurrencyKey CurrencyInId { get; set; }

        TCurrencyKey CurrencyOutId { get; set; }

        bool DisplayDirectRate { get; set; }
    }
}
