using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public class CRMMain
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("CRM.Main");

        public static uint DefaultTablePageSize
        {
            get
            {
                return uint.Parse(Section[nameof(DefaultTablePageSize)]);
            }
        }

        public static string ClientSideTemplatesPath
        {
            get
            {
                return Section[nameof(ClientSideTemplatesPath)];
            }
        }
    }
}
