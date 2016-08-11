using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Database
{
    public interface IRepositoryComposition<TEntity, TKey>
    {
        IRepository<TEntity, TKey> Repository { get; }
    }
}
