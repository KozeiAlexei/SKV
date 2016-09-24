using System;
using System.IO;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

using SKV.PL.ClientSide.Abstract;

namespace SKV.PL.ClientSide.Concrete
{
    public class MvcTemplate : IMvcTemplate
    {
        private static object SyncRoot { get; } = new object();
        private static string TemplatesRoot { get; } = HttpContext.Current.Server.MapPath(CRMConfiguration.ClientSideTemplatesPath);
        private static Dictionary<string, string> TemplateCache { get; } = new Dictionary<string, string>();

        private StringBuilder TemplateBuilder { get; set; } = default(StringBuilder);

        public MvcTemplate(string template_name)
        {
            var template = default(string);
            try
            {
                lock (SyncRoot)
                {
                    if (!TemplateCache.ContainsKey(template_name))
                    {
                        using (var reader = new StreamReader($"{ TemplatesRoot }{ template_name }Template.html"))
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

            TemplateBuilder = new StringBuilder(template);
        }

        public void SetParameter(string param_name, string param_value) => TemplateBuilder.Replace($"#{ param_name }#", param_value);
        public void SetParameter(string param_name, Func<string> param_value_func) => SetParameter(param_name, param_value_func());

        public MvcHtmlString Render() => MvcHtmlString.Create(TemplateBuilder.ToString());
    }
}