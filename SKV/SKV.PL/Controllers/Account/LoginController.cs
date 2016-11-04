using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Controllers.Account
{

    [RoutePrefix("Account/Login")]
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public ViewResult Index() => View();
    }
}