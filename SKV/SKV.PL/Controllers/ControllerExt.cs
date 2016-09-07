
using Ninject;
using SKV.BLL;
using SKV.BLL.Abstract.UI;
using SKV.PL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Controllers
{
    [Localize]
    [RequireHttps]
    public class ControllerExt : Controller
    {
        private IUICultureManager ui_culture_manager = BLLDependencyResolver.Kernel.Get<IUICultureManager>();
        private IUIMenuItemManager ui_menuitem_manager = BLLDependencyResolver.Kernel.Get<IUIMenuItemManager>();

        public ControllerExt()
        {
            var culture = ui_culture_manager.GetDefaultCulture().Culture;
            var cultures = ui_culture_manager.GetUICultures();

            ViewBag.UICultures = cultures;
            ViewBag.UIMenuItems = ui_menuitem_manager.GenerateMenuTree();
        }

        public ActionResult ChangeCulture(string culture)
        {
            var cultures = ui_culture_manager.GetUICultures();

            if (!cultures.Where(c => c.Culture == culture).Any())
                culture = ui_culture_manager.GetDefaultCulture().Culture;

            var cookie = Request.Cookies[PLStaticData.CultureCookieName];
            if (cookie != null)
                cookie.Value = culture;
            else
            {
                cookie = new HttpCookie(PLStaticData.CultureCookieName)
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1),
                    HttpOnly = false
                };
            }

            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

    }
}