using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKV.ML.ViewModels.Administration.Security.Role;
using Microsoft.AspNet.Identity;

namespace SKV.BLL.Abstract.Identity
{
    public interface IIdentityRoleManager<TRole> : IDisposable
    {
        IEnumerable<TRole> GetRoles();

        Task<IEnumerable<TRole>> GetRolesAsync();
        Task<IdentityResult> UpdateRoleDataAsync(UserRole role);
        Task<IdentityResult> CreateAsync(RoleCreatingViewModel model);
        Task<IdentityResult> DeleteRoleAsync(string id);
    }
}
