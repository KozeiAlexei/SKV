using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.UIModel;
using SKV.DAL.Abstract.Repositories.UIModel;

namespace SKV.DAL.Concrete.Repositories.UIModel
{
    public class UIMenuItemRepository : IUIMenuItemRepository<UIMenuItem, int, int?>
    {
        public IRepository<UIMenuItem, int> Repository { get; } =
            (IRepository<UIMenuItem, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UIMenuItem, int>));

        public IEnumerable<UIMenuItem> GetChildItems(int? parent_id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.ParentId == parent_id));
    }
}
