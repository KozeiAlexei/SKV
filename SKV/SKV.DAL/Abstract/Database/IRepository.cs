using System;
using System.Linq;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Database
{
    public interface IRepository<TEntity, TKey> : ICRUD<TEntity, TKey> 
        where TEntity : class, ICloneableFrom<TEntity>, IEntity<TKey> where TKey : IComparable<TKey>
    {
        IQueryable<TEntity> Table { get; }
    }
}
