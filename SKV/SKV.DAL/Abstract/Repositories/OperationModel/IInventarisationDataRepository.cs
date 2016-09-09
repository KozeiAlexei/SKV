using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IInventarisationDataRepository<TEntity, TKey, TInventarisationKey, TWindowKey, TCurrencyKey, TResult> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IInventarisationData<TKey, TInventarisationKey, TWindowKey, TCurrencyKey, TResult>
    {
    }
}
