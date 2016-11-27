namespace SKV.Configuration
{
    public class AngularControllerDefaults
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.ControllerDefaults");

        public static string CurrentUser
        {
            get
            {
                return section[nameof(CurrentUser)];
            }
        }

        public static string CurrentRole
        {
            get
            {
                return section[nameof(CurrentRole)];
            }
        }

        public static string PasswordChanging
        {
            get
            {
                return section[nameof(PasswordChanging)];
            }
        }
    }
}
