using System.ComponentModel.DataAnnotations;

namespace SKV.PL.ClientSide.Components.NotificationList
{
    public class NotificationListMvcModel
    {
        [Required]
        public string NotificationsControllerPath { get; set; }
    }
}