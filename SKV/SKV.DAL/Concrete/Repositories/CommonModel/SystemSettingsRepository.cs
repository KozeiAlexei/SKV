using System.Linq;
using System.Data.Entity;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.CommonModel;
using SKV.DAL.Abstract.Repositories.CommonModel;

namespace SKV.DAL.Concrete.Repositories.CommonModel
{
    public class SystemSettingsRepository : ISystemSettingsRepository<SystemSettings, int, int>
    {
        public IRepository<SystemSettings, int> Repository { get; } =
            (IRepository<SystemSettings, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<SystemSettings, int>));

        public SystemSettings GetSystemSettings() =>
            Repository.Sync.Synchronize(() => Repository.Table.Include(r => r.DefaultUICultureInstance)
                                                              .SingleOrDefault());
    }
}
