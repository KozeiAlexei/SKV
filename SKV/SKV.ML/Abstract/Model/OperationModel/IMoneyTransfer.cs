using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.OperationModel
{
    public interface IMoneyTransfer<TKey, TUserKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<IMoneyTransfer<TKey, TUserKey, TStatusKey>>
    {
    }
}
