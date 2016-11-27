using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace SKV.Configuration
{
    public static class CRMCoreConfigurationManager
    {
        private static XmlDocument config = default(XmlDocument);
        private static string config_name = "CRMCore.config";

        static CRMCoreConfigurationManager()
        {
            var path = Path.Combine(Path.GetDirectoryName(typeof(CRMCoreConfigurationManager).Assembly.Location), config_name);
            if (path.Contains(nameof(Microsoft)) || path.Contains("AppData"))
                path = System.Web.Hosting.HostingEnvironment.MapPath($"~/Components/Configurator/{ config_name }");

            config = new XmlDocument(); config.Load(path);
        }

        public static CRMCoreConfigurationSection GetSection(string section_name) =>
            new CRMCoreConfigurationSection(config.SelectSingleNode($"/Configuration/{ section_name }").ChildNodes);
    }

    public class CRMCoreConfigurationSection
    {
        private XmlNodeList @params = default(XmlNodeList);

        public CRMCoreConfigurationSection(XmlNodeList @crm_params) { @params = @crm_params; }

        public string this[string key]
        {
            get
            {
                return @params.Cast<XmlNode>().Where(n => n.Attributes["key"].Value == key)
                                              .Select(n => n.Attributes).FirstOrDefault()["value"].Value;
            }
        }
    }
}
