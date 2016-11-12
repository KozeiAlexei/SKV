using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.PL.ClientSide.Concrete
{
    public static class NamesGenerator
    {
        public static string GetControllerNotificationsPath(string controllerAs) => $"{ controllerAs }.Notifications";

        public static string GetModalId(string modalName) => $"{ modalName }Modal";

        public static string GetTabsId(string tabsName) => $"{ tabsName }Modal";
    }
}
