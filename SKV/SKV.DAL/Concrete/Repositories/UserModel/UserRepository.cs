using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;

namespace SKV.DAL.Concrete.Repositories.UserModel
{
    public class UserRepository : IUserRepository<User, string>
    {
        public IRepository<User, string> Repository { get; } =
            (IRepository<User, string>)DALDependencyResolver.Kernel.Get(typeof(IRepository<User, string>));

        public User GetUserByAsteriskNumber(int asterisk_number) =>
            Repository.Sync.Synchronize(() => Repository.Table
                                                        .Include(e => e.Profile)
                                                        .Where(e => e.Profile.AsteriskId == asterisk_number).FirstOrDefault());

        public User GetUserById(string id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Id == id).FirstOrDefault());

        public User GetUserByName(string name) =>
            Repository.Sync.Synchronize(() => Repository.Table
                                                        .Include(e => e.Profile)
                                                        .Where(e => e.Profile.Name == name).FirstOrDefault());

        public User GetUserByPhone(string phone) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.PhoneNumber == phone).FirstOrDefault());


        public IEnumerable<User> GetUsers() =>
            Repository.Sync.Synchronize(() => Repository.Table
                                                        .Include(e => e.Profile)
                                                        .AsNoTracking());


        public IEnumerable<string> GetUserNames() =>
            Repository.Sync.Synchronize(() => Repository.Table
                                                        .Include(e => e.Profile)
                                                        .Select(e => e.Profile.Name));
    }
}
