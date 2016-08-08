using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CurrencyModel
{
    public interface ICurrencyCompetitor<TKey> : IEntity<TKey>, ICloneableFrom<ICurrencyCompetitor<TKey>>
    {
        string Name { get; set; }

        string Source { get; set; }

        string ShortName { get; set; }
    }
}
