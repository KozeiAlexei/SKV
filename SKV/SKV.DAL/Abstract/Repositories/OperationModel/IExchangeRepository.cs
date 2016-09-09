using System.Collections.Generic;

using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IExchangeRepository<TEntity, TKey, TExchangeSource, TUserKey, TClientKey, TWindowKey, TStatusKey>
                      : IOperationRepository<TEntity, TKey, TUserKey, TStatusKey>
        where TEntity : IExchange<TKey, TExchangeSource, TUserKey, TClientKey, TWindowKey, TStatusKey>
    {
        IEnumerable<TEntity> GetExpiredExchanges();
        IEnumerable<TEntity> GetExchangesByClientId(int client_id);
        IEnumerable<TEntity> GetExchangesCanceledByClientReason(int client_id);
    }
}
