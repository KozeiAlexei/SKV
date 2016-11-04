using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularFactoryNames
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.FactoryNames");

        public static string UserTableSettingsFactory
        {
            get
            {
                return section[nameof(UserTableSettingsFactory)];
            }
        }

        public static string RoleTableSettingsFactory
        {
            get
            {
                return section[nameof(RoleTableSettingsFactory)];
            }
        }
    }
}
