using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularControllerAs
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("Angular.ControllerAs");

        public static string UserManagerControllerAs
        {
            get
            {
                return Section[nameof(UserManagerControllerAs)];
            }
        }

        public static string AngularRoleManagerControllerAs
        {
            get
            {
                return Section[nameof(AngularRoleManagerControllerAs)];
            }
        }
    }
}
