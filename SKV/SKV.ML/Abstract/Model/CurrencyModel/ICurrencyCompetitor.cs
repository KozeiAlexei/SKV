using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.CurrencyModel
{
    public interface ICurrencyCompetitor<TKey> : IEntity<TKey>, ICloneableFrom<ICurrencyCompetitor<TKey>>
    {
        string Name { get; set; }

        string Source { get; set; }

        string ShortName { get; set; }
    }
}
