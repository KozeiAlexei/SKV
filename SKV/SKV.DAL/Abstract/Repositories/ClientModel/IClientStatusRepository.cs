using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.ClientModel;

namespace SKV.DAL.Abstract.Repositories.ClientModel
{
    public interface IClientStatusRepository<TEntity, TKey, TStatus> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IClientStatus<TKey, TStatus>
        where TStatus : struct
    {
        TEntity GetStatusByCode(TStatus code);
    }
}
