using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.OperationModel
{
    public interface ICorrection<TKey, TUserKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<ICorrection<TKey, TUserKey, TStatusKey>>
    {
    }
}
