using SKV.DAL.Abstract.Database;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserRoleRepository<TEntity, TKey, TDefaultRole> : IRepositoryComposition<TEntity, TKey>
    {
        TEntity GetRoleById(TKey id);

        TEntity GetRoleByName(string name);
    }
}
