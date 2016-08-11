using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;

namespace SKV.DAL.Concrete.Repositories.UserModel
{
    public class UserRoleRepository : IUserRoleRepository<UserRole, string, DefaultRole>
    {
        public IRepository<UserRole, string> Repository { get; } =
            (IRepository<UserRole, string>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UserRole, string>));

        public UserRole GetRoleById(string id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Id == id).FirstOrDefault());

        public UserRole GetRoleByName(string name) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Name == name).FirstOrDefault());
    }
}
