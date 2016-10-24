using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Abstract.Repositories.UIModel
{
    public interface IUIComponentDataRepository<TEntity, TKey, TComponentData> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUIComponentData<TKey, TComponentData>
    {
        TEntity GetUIComponentDataById(TKey id);
    }
}
