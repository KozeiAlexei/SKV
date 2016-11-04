using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SKV.PL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ModuleRoute0", "{controller}/{action}");

            routes.MapRoute("ModuleRoute1", "{module}/{controller}/{action}",
                defaults: new { module = "Account", controller = "Login", action = "Index" });

            routes.MapRoute("ModuleRoute2", "{module}/{submodule}/{controller}/{action}");
        }
    }
}
