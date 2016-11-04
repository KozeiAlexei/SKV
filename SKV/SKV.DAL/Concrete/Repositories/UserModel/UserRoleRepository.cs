using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.UserModel;
using SKV.DAL.Abstract.Repositories.UserModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;

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

        public IEnumerable<UserRole> GetRoles() => 
            Repository.Sync.Synchronize(() => Repository.Table.Include(e => e.PageInstance).Include(e => e.Permissions));
    }
}
