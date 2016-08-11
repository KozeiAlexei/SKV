using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.WindowModel;

namespace SKV.DAL.Abstract.Repositories.WindowModel
{
    public interface IWindowRepository<TEntity, TKey, TWindowStatus> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IWindow<TKey, TWindowStatus>
    {
        IEnumerable<string> GetWindowNames();
        IEnumerable<TEntity> GetWindowsByStatus(TWindowStatus status);

        TEntity GetWindowByName(string name);

    }
}
