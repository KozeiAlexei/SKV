using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.Configuration
{
    public class UIObjectNames
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("UI.ObjectNames");

        public static string RolePermissionsTab
        {
            get
            {
                return section[nameof(RolePermissionsTab)];
            }
        }

        public static string RoleMainPropertiesTab
        {
            get
            {
                return section[nameof(RoleMainPropertiesTab)];
            }
        }

        public static string ControllerNotificationsPath
        {
            get
            {
                return section[nameof(ControllerNotificationsPath)];
            }
        }

        public static string RoleProfile
        {
            get
            {
                return section[nameof(RoleProfile)];
            }
        }

        public static string RoleProfileMainPropertiesFields
        {
            get
            {
                return section[nameof(RoleProfileMainPropertiesFields)];
            }
        }
    }
}
