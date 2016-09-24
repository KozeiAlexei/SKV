using System.Configuration;

namespace SKV.PL
{
    public class CRMConfiguration
    {
        #region Angular configuration

        public static string AngularApplicationName
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(AngularApplicationName)];
            }
        }

        public static string AngularDynamicTableControllerName
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(AngularDynamicTableControllerName)];
            }
        }

        public static string AngularUserTableSettingsFactory
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(AngularUserTableSettingsFactory)];
            }
        }

        public static string AngularUserManagerController
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(AngularUserManagerController)];
            }
        }

        public static string AngularUserManagerControllerName
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(AngularUserManagerControllerName)];
            }
        }

        #endregion

        #region ClientSide configuration

        public static string ClientSideTemplatesPath
        {
            get
            {
                return ConfigurationManager.AppSettings[nameof(ClientSideTemplatesPath)];
            }
        }

        #endregion
    }
}