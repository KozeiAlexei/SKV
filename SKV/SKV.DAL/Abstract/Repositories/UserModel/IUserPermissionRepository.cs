using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.UserModel;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserPermissionRepository<TEntity, TKey, TPermission> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUserPermission<TKey, TPermission>
    {
    }
}
