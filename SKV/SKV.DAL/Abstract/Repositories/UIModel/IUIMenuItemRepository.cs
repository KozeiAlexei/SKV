using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.UIModel;

namespace SKV.DAL.Abstract.Repositories.UIModel
{
    public interface IUIMenuItemRepository<TEntity, TKey, TParentKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUIMenuItem<TKey, TParentKey>
    {
        IEnumerable<TEntity> GetChildItems(TParentKey parent_id);
    }
}
