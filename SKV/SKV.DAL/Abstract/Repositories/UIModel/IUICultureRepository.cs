using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.UIModel;

namespace SKV.DAL.Abstract.Repositories.UIModel
{
    public interface IUICultureRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUICulture<TKey>
    {
    }
}
