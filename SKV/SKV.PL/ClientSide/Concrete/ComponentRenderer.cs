using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using RazorEngine;
using RazorEngine.Templating;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SKV.PL.ClientSide.Concrete
{
    public class ComponentRenderer
    {
        private static object SyncRoot { get; } = new object();
        private static string TemplatesRoot { get; } = HttpContext.Current.Server.MapPath("~/Views/ComponentTemplates/");
        private static Dictionary<string, string> TemplateCache { get; } = new Dictionary<string, string>();

        public ComponentRenderer(string template_name)
        {
            var template = default(string);
            try
            {
                lock (SyncRoot)
                {
                    if (!TemplateCache.ContainsKey(template_name))
                    {
                        using (var reader = new StreamReader($"{ TemplatesRoot }{ template_name }Template.cshtml"))
                            template = reader.ReadToEnd();

                        TemplateCache.Add(template_name, template);
                    }
                    else
                        TemplateCache.TryGetValue(template_name, out template);
                }
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Error loading client side template!", ex);
            }
            finally
            {
                ComponentTemplate = template;
                ComponentTemplateName = template_name;
            }
        }

        private string ComponentTemplate { get; set; }
        private string ComponentTemplateName { get; set; }

        public MvcHtmlString Render<TModel>(TModel model)
        {
            var validation_result = new List<ValidationResult>();
            if (Validator.TryValidateObject(model, new ValidationContext(model, null, null), validation_result))
            {
                return MvcHtmlString.Create(new ViewRenderer().RenderPartialViewToString($"~/Views/ComponentTemplates/{ ComponentTemplateName }Template.cshtml", model));

                //var service = Engine.Razor;
                //var template_key = new NameOnlyTemplateKey(ComponentTemplateName, ResolveType.Layout, null);

                //service.AddTemplate(template_key, ComponentTemplate);
                //service.Compile(template_key, typeof(TModel));

                //return MvcHtmlString.Create(service.Run(template_key, typeof(TModel), model));
            }
            else
                throw new Exception($"ComponentModel has some validation errors");
        }
    }
}