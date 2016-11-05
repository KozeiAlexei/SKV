using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.UserModel;
using System.Collections.Generic;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserPermissionRepository<TEntity, TKey, TPermission> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUserPermission<TKey, TPermission>
    {
        IEnumerable<TEntity> GetPermissions();
    }
}
