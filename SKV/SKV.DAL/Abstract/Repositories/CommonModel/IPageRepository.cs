using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.CommonModel;

namespace SKV.DAL.Abstract.Repositories.CommonModel
{
    public interface IPageRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IPage<TKey>
    {
        TEntity GetPageByName(string name);

        IEnumerable<string> GetPageNames();
    }
}
