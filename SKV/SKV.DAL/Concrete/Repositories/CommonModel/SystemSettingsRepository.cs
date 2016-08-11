using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CommonModel;
using SKV.DAL.Abstract.Repositories.CommonModel;

namespace SKV.DAL.Concrete.Repositories.CommonModel
{
    public class SystemSettingsRepository : ISystemSettingsRepository<SystemSettings, int>
    {
        public IRepository<SystemSettings, int> Repository { get; } =
            (IRepository<SystemSettings, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<SystemSettings, int>));

        public SystemSettings GetSystemSettings() =>
            Repository.Sync.Synchronize(() => Repository.Table.SingleOrDefault());
    }
}
