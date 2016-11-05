using SKV.BLL.Identity;
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
        private IdentityRoleManager RoleManager { get; } = new IdentityRoleManager();

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IHttpActionResult> GetRoles() => Json(await RoleManager.GetRolesAsync());
    }
}