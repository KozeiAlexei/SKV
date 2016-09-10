using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
