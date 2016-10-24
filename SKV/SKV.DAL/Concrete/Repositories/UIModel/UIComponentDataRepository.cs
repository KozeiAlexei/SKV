using SKV.DAL.Abstract.Repositories.UIModel;
using SKV.ML.Concrete.Model.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKV.DAL.Abstract.Database;
using Ninject;

namespace SKV.DAL.Concrete.Repositories.UIModel
{
    public class UIComponentDataRepository : IUIComponentDataRepository<UIComponentData, int, string>
    {
        public IRepository<UIComponentData, int> Repository { get; } =
            (IRepository<UIComponentData, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UIComponentData, int>));

        public UIComponentData GetUIComponentDataById(int id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Id == id).FirstOrDefault());
    }
}
