using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IMoneyTransferDataRepository<TEntity, TKey, TMoneyTransferKey, TWindowKey, TCurrencyKey, TMoneyTransferBase> 
                      : IRepositoryComposition<TEntity, TKey>
        where TEntity : IMoneyTransferData<TKey, TMoneyTransferKey, TWindowKey, TCurrencyKey, TMoneyTransferBase>
    {
    }
}
