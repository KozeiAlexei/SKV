using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.Abstract.Identity
{
    public interface IIdentityRoleManager<TRole> : IDisposable
    {
        IEnumerable<TRole> GetRoles();

        Task<IEnumerable<TRole>> GetRolesAsync();
    }
}
