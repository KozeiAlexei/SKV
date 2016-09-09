using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IMoneyTransferRepository<TEntity, TKey, TUserKey, TStatusKey> : IOperationRepository<TEntity, TKey, TUserKey, TStatusKey>
        where TEntity : IMoneyTransfer<TKey, TUserKey, TStatusKey>
    {

    }
}
