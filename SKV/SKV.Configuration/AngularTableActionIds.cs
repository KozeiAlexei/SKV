using System.Configuration;
using System.Collections.Specialized;

namespace SKV.Configuration
{
    public static class AngularTableActionIds
    {
        private static ClassLibraryConfigSection Section { get; } = SectionHelper.GetSection("Angular.TableActionIds");

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
