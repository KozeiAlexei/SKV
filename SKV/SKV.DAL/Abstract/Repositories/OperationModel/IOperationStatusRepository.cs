using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IOperationStatusRepository<TEntity, TKey, TOperation, TStatus> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IOperationStatus<TKey, TOperation, TStatus>
    {
        TEntity GetStatusByTypeAndCode(TOperation type, TStatus code);
    }
}
