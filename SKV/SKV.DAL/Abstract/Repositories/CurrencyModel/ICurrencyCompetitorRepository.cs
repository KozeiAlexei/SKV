using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Abstract.Repositories.CurrencyModel
{
    public interface ICurrencyCompetitorRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICurrencyCompetitor<TKey>
    {

    }
}
