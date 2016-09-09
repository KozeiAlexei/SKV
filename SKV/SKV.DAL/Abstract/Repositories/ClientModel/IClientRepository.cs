using System;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.ClientModel;

namespace SKV.DAL.Abstract.Repositories.ClientModel
{
    public interface IClientRepository<TEntity, TKey, TStatusKey, TClientCode> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IClient<TKey, TStatusKey, TClientCode>
    {
        TEntity GetClientByPhone(string phone);

        bool IsExistClient(string phone);

        string GetNextClientCode();
    }
}
