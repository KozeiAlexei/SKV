using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.UIModel;

namespace SKV.DAL.Abstract.Repositories.UIModel
{
    public interface IUICultureRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUICulture<TKey>
    {
    }
}
