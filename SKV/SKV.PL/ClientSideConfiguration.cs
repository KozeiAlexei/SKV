using System.Collections.Specialized;
using System.Configuration;

namespace SKV.PL
{
    public class ClientSideConfiguration
    {
        private static NameValueCollection Section { get; } = 
            (NameValueCollection)ConfigurationManager.GetSection(nameof(ClientSideConfiguration));

        public static string AngularApplicationName
        {
            get
            {
                return Section[nameof(AngularApplicationName)];
            }
        }

        public static string AngularDynamicTableControllerName
        {
            get
            {
                return Section[nameof(AngularDynamicTableControllerName)];
            }
        }

        public static string AngularUserTableSettingsFactory
        {
            get
            {
                return Section[nameof(AngularUserTableSettingsFactory)];
            }
        }

        public static string AngularUserManagerController
        {
            get
            {
                return Section[nameof(AngularUserManagerController)];
            }
        }

        public static string AngularUserManagerControllerName
        {
            get
            {
                return Section[nameof(AngularUserManagerControllerName)];
            }
        }

        public static uint DefaultTablePageSize
        {
            get
            {
                return uint.Parse(Section[nameof(DefaultTablePageSize)]);
            }
        }

        public static string ViewActionId
        {
            get
            {
                return Section[nameof(ViewActionId)];
            }
        }

        public static string DeleteActionId
        {
            get
            {
                return Section[nameof(DeleteActionId)];
            }
        }
    }
}