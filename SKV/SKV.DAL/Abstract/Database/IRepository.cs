using System;
using System.Linq;

using SKV.DAL.Abstract.Entity;
using SKV.DAL.Abstract.Common;

namespace SKV.DAL.Abstract.Database
{
    public interface IRepository<TEntity, TKey> : ICRUD<TEntity, TKey>
    {
        ISynchronizator Sync { get; }

        IQueryable<TEntity> Table { get; }
    }
}
