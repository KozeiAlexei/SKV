using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.EntityFramework;
using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.Identity
{
    public class IdentityRoleManager : IDisposable
    {
        private RoleManager<UserRole> RoleManager { get; set; }

        private IDbManager DbManager { get; set; }

        public static IdentityRoleManager Create() => new IdentityRoleManager();
            
        public IdentityRoleManager()
        {
            DbManager = DALDependencyResolver.Kernel.Get<IDbManager>();
            RoleManager = new RoleManager<UserRole>(new RoleStore<UserRole>(new DatabaseContext()));
        }

        public async Task<IEnumerable<UserRole>> GetRolesAsync() => await Task.Run(() => DbManager.UserRoles.GetRoles());

        public void Dispose() => RoleManager.Dispose();
    }
}
