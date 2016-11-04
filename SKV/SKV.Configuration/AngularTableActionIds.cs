using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularTableActionIds
    {
        private static CRMCoreConfigurationSection section = CRMCoreConfigurationManager.GetSection("Angular.TableActionIds");

        public static string ViewActionId
        {
            get
            {
                return section[nameof(ViewActionId)];
            }
        }

        public static string DeleteActionId
        {
            get
            {
                return section[nameof(DeleteActionId)];
            }
        }
    }
}
