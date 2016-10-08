/* This code from https://github.com/RickStrahl/WestwindToolkit/blob/master/Westwind.Web.Mvc/Utils/ViewRenderer.cs and it was corrected */

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SKV.PL.ClientSide.Concrete
{
    public class ViewRenderer
    {
        public ViewRenderer(ControllerContext controller_context = null)
        {
            if (controller_context == null)
            {
                if (HttpContext.Current != null)
                    controller_context = CreateController<FakeController>().ControllerContext;
                else
                    throw new InvalidOperationException();
            }
            Context = controller_context;
        }

        protected ControllerContext Context { get; set; }

        public string RenderViewToString(string view_path, object model = null) => 
            RenderViewToStringInternal(view_path, model, false);

        public string RenderPartialViewToString(string view_path, object model = null) => 
            RenderViewToStringInternal(view_path, model, true);


        public static string RenderView(string view_path, object model, ControllerContext controller_context) =>
            new ViewRenderer(controller_context).RenderViewToString(view_path, model);


        public static string RenderPartialView(string view_path, object model, ControllerContext controller_context) =>
            new ViewRenderer(controller_context).RenderPartialViewToString(view_path, model);

        private string RenderViewToStringInternal(string view_path, object model, bool partial = false)
        {
            var view_engine_result = default(ViewEngineResult);
            if (partial)
                view_engine_result = ViewEngines.Engines.FindPartialView(Context, view_path);
            else
                view_engine_result = ViewEngines.Engines.FindView(Context, view_path, null);

            if (view_engine_result == null || view_engine_result.View == null)
                throw new FileNotFoundException();

            var view = view_engine_result.View;
            Context.Controller.ViewData.Model = model;

            var result = default(string);
            using (var writer = new StringWriter())
            {
                var context = new ViewContext(Context, view, Context.Controller.ViewData, Context.Controller.TempData, writer);
                view.Render(context, writer);

                result = writer.ToString();
            }

            return result;
        }

        public static T CreateController<T>(RouteData route_data = null, params object[] parameters) where T : Controller, new()
        {
            var controller = (T)Activator.CreateInstance(typeof(T), parameters);

            var wrapper = default(HttpContextBase);
            if (HttpContext.Current != null)
                wrapper = new HttpContextWrapper(HttpContext.Current);
            else
                throw new InvalidOperationException("Can't create Controller Context if no active HttpContext instance is available.");

            if (route_data == null)
                route_data = new RouteData();

            if (!route_data.Values.ContainsKey("controller") && !route_data.Values.ContainsKey("Controller"))
                route_data.Values.Add("controller", controller.GetType().Name.ToLower().Replace("controller", ""));

            controller.ControllerContext = new ControllerContext(wrapper, route_data, controller);

            return controller;
        }

    }

    public class FakeController : Controller { }
}