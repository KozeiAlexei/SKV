using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Database
{
    public interface IRepositoryComposition<TEntity, TKey>
        where TKey : IComparable<TKey>
        where TEntity : class, IEntity<TKey>, ICloneableFrom<TEntity>
    {
        IRepository<TEntity, TKey> Repository { get; }
    }
}
