using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;

namespace SKV.DAL.Concrete.Repositories.UserModel
{
    public class UserProfileRepository : IUserProfileRepository<UserProfile, string>
    {
        public IRepository<UserProfile, string> Repository { get; } =
            (IRepository<UserProfile, string>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UserProfile, string>));
    }
}
