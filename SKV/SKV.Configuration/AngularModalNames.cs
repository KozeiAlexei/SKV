using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularModalNames
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.ModalNames");

        public static string UserProfileModalName
        {
            get
            {
                return section[nameof(UserProfileModalName)];
            }
        }

        public static string UserCreatingModalName
        {
            get
            {
                return section[nameof(UserCreatingModalName)];
            }
        }

        public static string RoleProfileModalName
        {
            get
            {
                return section[nameof(RoleProfileModalName)];
            }
        }

        public static string RoleCreatingModalName
        {
            get
            {
                return section[nameof(RoleCreatingModalName)];
            }
        }

        public static string ConfirmationModalName
        {
            get
            {
                return section[nameof(ConfirmationModalName)];
            }
        }
    }
}
