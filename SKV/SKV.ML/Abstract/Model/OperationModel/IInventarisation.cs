using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.OperationModel
{
    public interface IInventarisation<TKey, TUserKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<IInventarisation<TKey, TUserKey, TStatusKey>>
    {
    }
}
