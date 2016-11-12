using SKV.PL.ClientSide.Components;
using SKV.PL.ClientSide.Components.Tabs;
using SKV.PL.ClientSide.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CRMConfig = SKV.Configuration;

namespace SKV.PL.Controllers.Administration.Security
{
    [Authorize]
    [RoutePrefix("Administration/Security/RoleManager")]
    public class RoleManagerController : ControllerExt
    {
        [Route("Index")]
        public ViewResult Index() => View();

        public override string GetViewPath(string viewName) =>
            $"~/Views/Administration/Security/RoleManager/{ viewName }.cshtml";

        public override void SettingUICustom()
        {
            var roleNotificationsObject = CRMConfig.AngularObjectNames.ControllerNotificationsPath;

            var roleProfilePermissionsTabName = CRMConfig.AngularObjectNames.RolePermissionsTab;
            var roleProfileMainPropertiesTabName = CRMConfig.AngularObjectNames.RoleMainPropertiesTab;

            var roleProfilePermissionsTab = new TabMvcModel()
            {
                Id = roleProfilePermissionsTabName,
                Active = false, Title = Resources.Resource.PasswordChanging
            };

            var roleProfileMainPropertiesTab = new TabMvcModel()
            {
                Id = roleProfileMainPropertiesTabName,
                Active = true, Title = Resources.Resource.UserProfile
            };

            roleProfilePermissionsTab.Body.Create<ContentMvc>().FromPartitalView(GetViewPath(roleProfilePermissionsTabName), default(object));
            roleProfileMainPropertiesTab.Body.Create<ContentMvc>().FromPartitalView(GetViewPath(roleProfileMainPropertiesTabName), default(object));

            ViewData[roleProfilePermissionsTabName] = roleProfilePermissionsTab;
            ViewData[roleProfileMainPropertiesTabName] = roleProfileMainPropertiesTab;

            ViewBag.RoleProfileTabsId = NamesGenerator.GetTabsId(CRMConfig.AngularObjectNames.RoleProfile);
            ViewBag.RoleProfileModalId = NamesGenerator.GetModalId(CRMConfig.AngularObjectNames.RoleProfile);
            ViewBag.RoleControllerNotificationsPath = NamesGenerator.GetControllerNotificationsPath(CRMConfig.AngularControllerAs.RoleManagerControllerAs);
        }
    }
}