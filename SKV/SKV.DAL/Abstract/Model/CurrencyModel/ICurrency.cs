using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CurrencyModel
{
    public interface ICurrency<TKey> : IEntity<TKey>, ICloneableFrom<ICurrency<TKey>>
    {
        string Name { get; set; }

        string ShortName { get; set; }
    }
}
