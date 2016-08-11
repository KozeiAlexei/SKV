using SKV.DAL.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IInventarisationRepository<TEntity, TKey, TUserKey, TStatusKey> : IOperationRepository<TEntity, TKey, TUserKey, TStatusKey>
        where TEntity : IInventarisation<TKey, TUserKey, TStatusKey>
    {

    }
}
