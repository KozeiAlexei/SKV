using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;
using System;
using System.Linq;

namespace SKV.DAL.Concrete.Repositories.UserModel
{
    public class UserProfileRepository : IUserProfileRepository<UserProfile, string>
    {
        public IRepository<UserProfile, string> Repository { get; } =
            (IRepository<UserProfile, string>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UserProfile, string>));

        public UserProfile GetUserProfileById(string id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Id == id).FirstOrDefault());
    }
}
