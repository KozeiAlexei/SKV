using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface ICorrection<TKey, TUserKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<ICorrection<TKey, TUserKey, TStatusKey>>
    {
    }
}
