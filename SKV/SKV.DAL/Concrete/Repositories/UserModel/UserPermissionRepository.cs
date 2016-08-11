using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;

namespace SKV.DAL.Concrete.Repositories.UserModel
{
    public class UserPermissionRepository : IUserPermissionRepository<UserPermission, int, UserPermissionCode>
    {
        public IRepository<UserPermission, int> Repository { get; } =
            (IRepository<UserPermission, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UserPermission, int>));
    }
}
