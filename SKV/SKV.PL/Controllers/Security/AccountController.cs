using System.Web.Mvc;

namespace SKV.PL.Controllers.Security
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ViewResult Index() => View();
    }
}