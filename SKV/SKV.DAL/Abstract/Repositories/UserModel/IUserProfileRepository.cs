using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.UserModel;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserProfileRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUserProfile<TKey>
    {
        TEntity GetUserProfileById(TKey id);
    }
}
