using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.WindowModel;

namespace SKV.DAL.Abstract.Repositories.WindowModel
{
    public interface IWindowCashRepository<TEntity, TKey, TWindowKey, TCurrencyKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IWindowCash<TKey, TWindowKey, TCurrencyKey>
    {
        TEntity GetWindowCashByWindowIdByCurrencyId(int window_id, int currency_id);
    }
}
