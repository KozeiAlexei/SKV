using System.Linq;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;

using SKV.BLL.Abstract.UI;

using SKV.ML.Concrete.Model.UIModel;

using CRMConfig = SKV.Configuration;
using Ninject;
using SKV.PL.App_Start;

namespace SKV.PL.Filters
{
    public class LocalizeAttribute : FilterAttribute, IActionFilter
    {
        private IUICultureManager UICultureManager { get; set; }

        public LocalizeAttribute()
        {
            UICultureManager = NinjectWebCommon.Bootstrapper.Kernel.Get<IUICultureManager>(); 
        }

        public LocalizeAttribute(IUICultureManager uiCultureManager)
        {
            PLUtility.ThrowIfNull(uiCultureManager, nameof(uiCultureManager), () => UICultureManager = uiCultureManager);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var currentCulture = default(UICulture);
            var defaultCulture = UICultureManager.GetDefaultCulture();

            var cultures = UICultureManager.GetUICultures();

            var cultureCookie = filterContext.HttpContext.Request.Cookies[CRMConfig.CRMMain.CultureCookieName];
            if (cultureCookie != null)
                currentCulture = cultures.First(c => c.Culture == cultureCookie.Value);
            else
                currentCulture = defaultCulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(currentCulture.Culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(currentCulture.Culture);

            filterContext.Controller.ViewBag.CurrentUICulture = currentCulture.Name;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { }
    }
}