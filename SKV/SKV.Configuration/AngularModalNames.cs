using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularModalNames
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("Angular.ModalNames");

        public static string UserProfileModalName
        {
            get
            {
                return Section[nameof(UserProfileModalName)];
            }
        }

        public static string UserCreatingModalName
        {
            get
            {
                return Section[nameof(UserCreatingModalName)];
            }
        }

        public static string RoleProfileModalName
        {
            get
            {
                return Section[nameof(RoleProfileModalName)];
            }
        }

        public static string RoleCreatingModalName
        {
            get
            {
                return Section[nameof(RoleCreatingModalName)];
            }
        }

        public static string ConfirmationModalName
        {
            get
            {
                return Section[nameof(ConfirmationModalName)];
            }
        }
    }
}
