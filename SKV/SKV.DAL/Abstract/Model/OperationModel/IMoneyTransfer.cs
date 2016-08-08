using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IMoneyTransfer<TKey, TUserKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<IMoneyTransfer<TKey, TUserKey, TStatusKey>>
    {
    }
}
