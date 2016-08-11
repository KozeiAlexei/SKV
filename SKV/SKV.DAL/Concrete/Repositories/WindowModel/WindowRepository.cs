using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.WindowModel;
using SKV.DAL.Abstract.Repositories.WindowModel;

namespace SKV.DAL.Concrete.Repositories.WindowModel
{
    public class WindowRepository : IWindowRepository<Window, int, WindowStatus>
    {
        public IRepository<Window, int> Repository { get; } =
            (IRepository<Window, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Window, int>));

        public Window GetWindowByName(string name) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Name == name).FirstOrDefault());

        public IEnumerable<string> GetWindowNames() =>
            Repository.Sync.Synchronize(() => Repository.Table.Select(e => e.Name));

        public IEnumerable<Window> GetWindowsByStatus(WindowStatus status) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Status == status));
    }
}
