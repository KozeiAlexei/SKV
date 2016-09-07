using SKV.PL.Tools;
using System.Web.Mvc;

namespace SKV.PL.Controllers.Security
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.StaticData = new ResourceHelper();

            return View();
        }
    }
}