using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Controllers.Administration.Security
{
    [Authorize]
    [RoutePrefix("Administration/Security/RoleManager")]
    public class RoleManagerController : ControllerExt
    {
        [Route("Index")]
        public ViewResult Index() => View();
    }
}