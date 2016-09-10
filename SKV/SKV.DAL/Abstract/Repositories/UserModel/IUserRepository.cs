using System.Collections.Generic;

using SKV.DAL.Abstract.Database;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
    {
        TEntity GetUserById(TKey id);
        TEntity GetUserByPhone(string phone);
        TEntity GetUserByName(string initials);
        TEntity GetUserByAsteriskNumber(int asterisk_number);

        IEnumerable<TEntity> GetUsers();

        IEnumerable<string> GetUserNames();
    }
}
