using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularFactoryNames
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("Angular.FactoryNames");

        public static string AngularUserTableSettingsFactory
        {
            get
            {
                return Section[nameof(AngularUserTableSettingsFactory)];
            }
        }

        public static string AngularRoleTableSettingsFactory
        {
            get
            {
                return Section[nameof(AngularRoleTableSettingsFactory)];
            }
        }
    }
}
