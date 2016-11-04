using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SKV.Configuration
{
    public static class SectionHelper
    {
        public static ClassLibraryConfigSection GetSection(string section_name)
        {
            var assembly = HttpUtility.UrlDecode(new Uri(Assembly.GetAssembly(typeof(SectionHelper)).CodeBase).AbsolutePath);
            var configuration = ConfigurationManager.OpenExeConfiguration(assembly);

            return (ClassLibraryConfigSection)configuration.Sections[section_name];
        }
    }

    public class ClassLibraryConfigSection: ConfigurationSection
    {
        public new string this[string key]
        {
            get { return base[key].ToString(); }
        }
    }
}
