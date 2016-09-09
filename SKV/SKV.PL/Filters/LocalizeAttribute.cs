using System.Linq;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using SKV.BLL.Abstract.UI;
using SKV.BLL;
using Ninject;

using SKV.ML.Concrete.Model.UIModel;

namespace SKV.PL.Filters
{
    public class LocalizeAttribute : FilterAttribute, IActionFilter
    {
        private IUICultureManager ui_culture_manager = BLLDependencyResolver.Kernel.Get<IUICultureManager>();

        public void OnActionExecuted(ActionExecutedContext filter_context)
        {
            var current_culture = default(UICulture);
            var default_culture = ui_culture_manager.GetDefaultCulture();

            var cultures = ui_culture_manager.GetUICultures();

            var culture_cookie = filter_context.HttpContext.Request.Cookies[PLStaticData.CultureCookieName];
            if (culture_cookie != null)
                current_culture = cultures.First(c => c.Culture == culture_cookie.Value);
            else
                current_culture = default_culture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(current_culture.Culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(current_culture.Culture);

            filter_context.Controller.ViewBag.CurrentUICulture = current_culture.Name;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { }
    }
}