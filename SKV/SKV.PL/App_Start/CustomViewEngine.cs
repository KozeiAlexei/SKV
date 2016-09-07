using System.Web.Mvc;

namespace SKV.PL.App_Start
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            var view_locations = new[]
            {
                "~/Views/Security/{1}/{0}.cshtml",
                "~/Views/App/{1}/{0}.cshtml"
            };

            ViewLocationFormats = view_locations;
            PartialViewLocationFormats = view_locations;
        }
    }
}