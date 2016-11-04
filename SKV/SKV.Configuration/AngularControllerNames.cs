using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularControllerNames
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("Angular.ControllerNames");

        public static string AngularUserManagerController
        {
            get
            {
                return Section[nameof(AngularUserManagerController)];
            }
        }

        public static string AngularRoleManagerController
        {
            get
            {
                return Section[nameof(AngularRoleManagerController)];
            }
        }
    }
}
