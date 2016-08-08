using System.Collections.Generic;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Database
{
    public interface ICRUD<TEntity, TKey> where TEntity : IEntity<TKey>, ICloneableFrom<TEntity>
    {
        TEntity Create(TEntity entity);

        IEnumerable<TEntity> Read();

        bool Update(TEntity entity);

        bool Delete(TKey id);
    }
}
