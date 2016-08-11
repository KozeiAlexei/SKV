using SKV.DAL.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface ICorrectionRepository<TEntity, TKey, TUserKey, TStatusKey> : IOperationRepository<TEntity, TKey, TUserKey, TStatusKey>
        where TEntity : ICorrection<TKey, TUserKey, TStatusKey>
    {

    }
}
