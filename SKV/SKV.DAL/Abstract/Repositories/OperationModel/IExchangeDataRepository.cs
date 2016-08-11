using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IExchangeDataRepository<TEntity, TKey, TExchangeKey, TCurrencyKey, TBankOperationKey> 
                      : IRepositoryComposition<TEntity, TKey>
        where TEntity : IExchangeData<TKey, TExchangeKey, TCurrencyKey, TBankOperationKey>
    {
    }
}
