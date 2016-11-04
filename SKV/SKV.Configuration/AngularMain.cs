using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public class AngularMain
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.Main");

        public static string ApplicationName
        {
            get
            {
                return section[nameof(ApplicationName)];
            }
        }

        public static string DynamicTableControllerAs
        {
            get
            {
                return section[nameof(DynamicTableControllerAs)];
            }
        }
    }
}
