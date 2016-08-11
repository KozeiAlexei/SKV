using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using Ninject;
using Ninject.Parameters;

using SKV.DAL.Abstract.Entity;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Common;

namespace SKV.DAL.Concrete.EntityFramework
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TKey : IComparable<TKey>
        where TEntity : class, IEntity<TKey>
    {
        private static object sync_context = new object();

        private static DatabaseContext context = default(DatabaseContext);

        public Repository()
        {
            context = DALDependencyResolver.Kernel.Get<DatabaseContext>();
        }

        public TEntity Create(TEntity entity)
            => Sync.Synchronize(() => context.Set<TEntity>().Add(entity));

        public IEnumerable<TEntity> Read()
            => Sync.Synchronize(() => context.Set<TEntity>().AsEnumerable());
        
        public bool Update(TEntity entity) 
        {
            return Sync.Synchronize(() =>
            {
                context.Entry(entity).State = EntityState.Modified;
                return true;
            });
        }

        public bool Delete(TKey id)
        {
            return Sync.Synchronize(() =>
            {
                context.Entry(Table.Where(e => e.Id.CompareTo(id) == 0).First()).State = EntityState.Deleted;
                return true;
            });
        }


        public ISynchronizator Sync { get; } = DALDependencyResolver.Kernel.Get<ISynchronizator>(new ConstructorArgument("sync_context", sync_context));

        public IQueryable<TEntity> Table { get; } = context.Set<TEntity>();
    }
}
