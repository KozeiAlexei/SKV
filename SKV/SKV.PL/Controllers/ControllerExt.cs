
using Ninject;
using SKV.BLL;
using SKV.BLL.Abstract.UI;
using SKV.PL.App_Start;
using SKV.PL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CRMConfig = SKV.Configuration;

namespace SKV.PL.Controllers
{
    [Localize]
    [RequireHttps]
    public class ControllerExt : Controller
    {
        private IUICultureManager UICultureManager { get; set; }
        private IUIMenuItemManager UIMenuItemManager { get; set; }

        public ControllerExt() : this(uiCultureManager: NinjectWebCommon.Bootstrapper.Kernel.Get<IUICultureManager>(),
                                      uiMenuItemManager: NinjectWebCommon.Bootstrapper.Kernel.Get<IUIMenuItemManager>())
        { }

        public ControllerExt(IUICultureManager uiCultureManager, IUIMenuItemManager uiMenuItemManager)
        {
            PLUtility.ThrowIfNull(uiCultureManager, nameof(uiCultureManager), () => UICultureManager = uiCultureManager);
            PLUtility.ThrowIfNull(uiMenuItemManager, nameof(uiMenuItemManager), () => UIMenuItemManager = uiMenuItemManager);

            SettingUIRequirements();
        }

        public ActionResult ChangeCulture(string culture)
        {
            var cultures = UICultureManager.GetUICultures();

            if (!cultures.Where(c => c.Culture == culture).Any())
                culture = UICultureManager.GetDefaultCulture().Culture;

            var cookie = Request.Cookies[CRMConfig.CRMMain.CultureCookieName];
            if (cookie != null)
                cookie.Value = culture;
            else
            {
                cookie = new HttpCookie(CRMConfig.CRMMain.CultureCookieName)
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1),
                    HttpOnly = false
                };
            }

            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        private void SettingUIRequirements()
        {
            ViewBag.UICultures = UICultureManager.GetUICultures();
            ViewBag.UIMenuItems = UIMenuItemManager.GenerateMenuTree();

            SettingUICustom();
        }

        protected virtual void SettingUICustom() { }

        protected virtual string GetViewPath(string viewName) { return viewName; }
    }
}