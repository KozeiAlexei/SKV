using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.ClientSide.Components.NotificationList
{
    public class NotificationListMvc : INotificationList
    {
        #region Constructor

        public NotificationListMvc()
        {
            Model = new NotificationListMvcModel();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private NotificationListMvcModel Model { get; set; }
        private IResponsibilityChain<NotificationListMvc> Chain { get; set; }

        #endregion

        #region Component setting

        public INotificationList NotificationsControllerPath(string path) => Chain.Responsibility(() => Model.NotificationsControllerPath = path);

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(NotificationListMvc)).Render(Model);
    }
}