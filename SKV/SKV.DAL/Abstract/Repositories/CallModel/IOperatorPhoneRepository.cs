using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.CallModel;

namespace SKV.DAL.Abstract.Repositories.CallModel
{
    public interface IOperatorPhoneRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IOperatorPhone<TKey>
    {
        TEntity GetOperatorPhoneByPhone(string phone);
    }
}
