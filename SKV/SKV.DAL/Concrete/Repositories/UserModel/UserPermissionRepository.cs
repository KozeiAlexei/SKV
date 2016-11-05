using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;

namespace SKV.DAL.Concrete.Repositories.UserModel
{
    public class UserPermissionRepository : IUserPermissionRepository<UserPermission, int, UserPermissionCode>
    {
        public IRepository<UserPermission, int> Repository { get; } =
            (IRepository<UserPermission, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UserPermission, int>));

        public IEnumerable<UserPermission> GetPermissions() => Repository.Sync.Synchronize(() => Repository.Table.AsEnumerable());
    }
}
