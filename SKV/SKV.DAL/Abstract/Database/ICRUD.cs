using System.Collections.Generic;

namespace SKV.DAL.Abstract.Database
{
    public interface ICRUD<TEntity, TKey>
    {
        TEntity Create(TEntity entity);

        IEnumerable<TEntity> Read();

        bool Update(TEntity entity);

        bool Delete(TKey id);
    }
}
