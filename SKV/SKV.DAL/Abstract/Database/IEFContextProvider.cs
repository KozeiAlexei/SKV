using System.Data.Entity;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Database
{
    public interface IEFContextProvider<TContext>
    {
        TContext Get();

        DbSet<TEntity> GetTable<TEntity, TKey>() where TEntity: class, IEntity<TKey>;
    }
}
