using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Controllers.Home
{
    [Authorize]
    public class HomeController : ControllerExt
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}