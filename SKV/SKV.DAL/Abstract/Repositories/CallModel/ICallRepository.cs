using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.CallModel;

namespace SKV.DAL.Abstract.Repositories.CallModel
{
    public interface ICallRepository<TEntity, TKey, TCallType> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICall<TKey, TCallType>
        where TCallType : struct
    {
        TEntity GetCallByAsteriskUniqueId(string id);
    }
}
