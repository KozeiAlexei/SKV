using Ninject;
using SKV.BLL.Abstract.Identity;
using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.Identity
{
    public class IdentityPermissionManager : IIdentityPermissionManager<UserPermission>
    {
        private IDbManager DbManager { get; set; } = DALDependencyResolver.Kernel.Get<IDbManager>();

        public async Task<IEnumerable<UserPermission>> GetPermissionsAsync() => await Task.Run(() => DbManager.UserPermissions.GetPermissions());


        public void Dispose()
        {
            DbManager = null;
        }

    }
}
