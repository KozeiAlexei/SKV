using System.Configuration;

namespace SKV.PL
{
    public class CRMConfiguration
    {
        public static string ClientSideTemplatesPath
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(ClientSideTemplatesPath)];
            }
        }
    }
}