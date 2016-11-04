using System.Web.Mvc;

namespace SKV.PL.Controllers.Home
{
    [Authorize]
    [RoutePrefix("Administration/Security/UserManager")]
    public class UserManagerController : ControllerExt
    {
        [Route("Index")]
        public ViewResult Index() => View();
    }
}