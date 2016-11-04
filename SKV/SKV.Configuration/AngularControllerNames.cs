using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularControllerNames
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.ControllerNames");

        public static string UserManagerController
        {
            get
            {
                return section[nameof(UserManagerController)];
            }
        }

        public static string RoleManagerController
        {
            get
            {
                return section[nameof(RoleManagerController)];
            }
        }
    }
}
