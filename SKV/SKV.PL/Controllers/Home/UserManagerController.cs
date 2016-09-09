using Microsoft.AspNet.Identity.Owin;
using SKV.BLL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Controllers.Home
{
    public class UserManagerController : ControllerExt
    {
        public IdentityUserManager UserManager
        {
            get { return Request.GetOwinContext().GetUserManager<IdentityUserManager>(); }
        }

        public async Task<ActionResult> Index() => View(await UserManager.GetUsers());
    }
}