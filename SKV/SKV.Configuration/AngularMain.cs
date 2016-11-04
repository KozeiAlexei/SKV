using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public class AngularMain
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("Angular.Main");

        public static string ApplicationName
        {
            get
            {
                return Section[nameof(ApplicationName)];
            }
        }

        public static string DynamicTableControllerAs
        {
            get
            {
                return Section[nameof(DynamicTableControllerAs)];
            }
        }
    }
}
