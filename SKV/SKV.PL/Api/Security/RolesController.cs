using SKV.BLL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SKV.PL.Api.Security
{
    [Authorize]
    [RoutePrefix("api/Security/Roles")]
    public class RolesController : ApiControllerExt
    {
        private IdentityRoleManager RoleManager { get; }
    }
}