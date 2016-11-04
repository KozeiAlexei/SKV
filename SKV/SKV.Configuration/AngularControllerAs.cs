using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularControllerAs
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.ControllerAs");

        public static string UserManagerControllerAs
        {
            get
            {
                return section[nameof(UserManagerControllerAs)];
            }
        }

        public static string RoleManagerControllerAs
        {
            get
            {
                return section[nameof(RoleManagerControllerAs)];
            }
        }
    }
}
