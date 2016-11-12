using SKV.BLL.Abstract.Identity;
using SKV.BLL.Identity;
using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SKV.PL.Api.Security
{
    [Authorize]
    [RoutePrefix("api/Administration/Security/Roles")]
    public class RolesController : ApiControllerExt
    {
        private IIdentityRoleManager<UserRole> RoleManager { get; set; }

        public RolesController(IIdentityRoleManager<UserRole> role_manager)
        {
            ThrowIfNull(role_manager, nameof(role_manager), postback: () => RoleManager = role_manager);
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IHttpActionResult> GetRoles() => Json(await RoleManager.GetRolesAsync());
    }
}