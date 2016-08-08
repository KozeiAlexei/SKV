using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IInventarisation<TKey, TUserKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<IInventarisation<TKey, TUserKey, TStatusKey>>
    {
    }
}
