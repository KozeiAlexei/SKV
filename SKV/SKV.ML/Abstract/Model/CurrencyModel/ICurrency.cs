using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.CurrencyModel
{
    public interface ICurrency<TKey> : IEntity<TKey>, ICloneableFrom<ICurrency<TKey>>
    {
        string Name { get; set; }

        string ShortName { get; set; }
    }
}
