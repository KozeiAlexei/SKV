using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface ICorrectionDataRepository<TEntity, TKey, TCorrectionKey, TWindowKey, TCurrencyKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICorrectionData<TKey, TCorrectionKey, TWindowKey, TCurrencyKey>
    {
    }
}
