using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public class CRMMain
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("CRM.Main");

        public static uint DefaultTablePageSize
        {
            get
            {
                return uint.Parse(section[nameof(DefaultTablePageSize)]);
            }
        }

        public static string ClientSideTemplatesPath
        {
            get
            {
                return section[nameof(ClientSideTemplatesPath)];
            }
        }
    }
}
