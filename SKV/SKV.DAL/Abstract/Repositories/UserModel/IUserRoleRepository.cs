using SKV.DAL.Abstract.Database;
using System.Collections.Generic;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserRoleRepository<TEntity, TKey, TDefaultRole> : IRepositoryComposition<TEntity, TKey>
    { 
        TEntity GetRoleById(TKey id);

        TEntity GetRoleByName(string name);

        IEnumerable<TEntity> GetRoles();
    }
}
