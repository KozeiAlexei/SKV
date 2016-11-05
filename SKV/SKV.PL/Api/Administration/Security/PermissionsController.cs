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

namespace SKV.PL.Api.Administration.Security
{
    [Authorize]
    [RoutePrefix("api/Administration/Security/Permissions")]
    public class PermissionsController : ApiControllerExt
    {
        private IIdentityPermissionManager<UserPermission> PermissionManager { get; set; } = default(IIdentityPermissionManager<UserPermission>);

        public PermissionsController(IIdentityPermissionManager<UserPermission> manager)
        {
            ThrowIfNull(manager, nameof(manager), postback: () => PermissionManager = manager);
        }

        [HttpGet]
        [Route("GetPermissions")]
        public async Task<IHttpActionResult> GetPermissions() => Json(await PermissionManager.GetPermissionsAsync());
    }
}
