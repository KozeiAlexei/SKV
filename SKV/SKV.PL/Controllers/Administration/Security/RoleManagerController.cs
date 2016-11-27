using SKV.BLL.Other;
using SKV.ML.Concrete;
using SKV.PL.ClientSide.Components;
using SKV.PL.ClientSide.Components.Tabs;
using SKV.PL.ClientSide.Components.VerticalFormField;
using SKV.PL.ClientSide.Concrete;
using SKV.PL.Models.PartialViewModels.Administration.Security;
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

        protected override string GetViewPath(string viewName) =>
            $"~/Views/Administration/Security/RoleManager/{ viewName }.cshtml";

        protected override void SettingUICustom()
        {
            var roleNotificationsObject = CRMConfig.UIObjectNames.ControllerNotificationsPath;

            var roleProfilePermissionsTabName = CRMConfig.UIObjectNames.RolePermissionsTab;
            var roleProfileMainPropertiesTabName = CRMConfig.UIObjectNames.RoleMainPropertiesTab;
            var roleProfileMainPropertiesFieldsName = CRMConfig.UIObjectNames.RoleProfileMainPropertiesFields;

            var roleProfilePermissionsTab = new TabMvcModel()
            {
                Id = roleProfilePermissionsTabName,
                Active = false, Title = Resources.Resource.RoleProfilePermissionsTab
            };

            var roleProfileMainPropertiesTab = new TabMvcModel()
            {
                Id = roleProfileMainPropertiesTabName,
                Active = true, Title = Resources.Resource.RoleProfileMainPropertiesTab
            };

            var roleProfilePermissionsTabModel = new RolePermissionsTabModel();
            var roleProfileMainPropertiesTabModel = new RoleMainPropertiesTabModel();

            roleProfilePermissionsTabModel.Fields.Add(CacheObject.Get<VerticalFormFieldMvcModel>(CacheItemClass.UI, (int)UIComponentKey.RoleManager_Permissions));
            roleProfileMainPropertiesTabModel.Fields.Add(CacheObject.Get<VerticalFormFieldMvcModel>(CacheItemClass.UI, (int)UIComponentKey.RoleManager_Name_Field));
            roleProfileMainPropertiesTabModel.Fields.Add(CacheObject.Get<VerticalFormFieldMvcModel>(CacheItemClass.UI, (int)UIComponentKey.RoleManager_PageInstance_Name_Field));

            roleProfilePermissionsTab.Body.Create<ContentMvc>().FromPartitalView(GetViewPath(roleProfilePermissionsTabName), roleProfilePermissionsTabModel);
            roleProfileMainPropertiesTab.Body.Create<ContentMvc>().FromPartitalView(GetViewPath(roleProfileMainPropertiesTabName), roleProfileMainPropertiesTabModel);

            ViewData[roleProfilePermissionsTabName] = roleProfilePermissionsTab;
            ViewData[roleProfileMainPropertiesTabName] = roleProfileMainPropertiesTab;

            ViewBag.RoleProfileTabsId = NamesGenerator.GetTabsId(CRMConfig.UIObjectNames.RoleProfile);
            ViewBag.RoleProfileModalId = NamesGenerator.GetModalId(CRMConfig.UIObjectNames.RoleProfile);
            ViewBag.RoleControllerNotificationsPath = NamesGenerator.GetControllerNotificationsPath(CRMConfig.AngularControllerAs.RoleManagerControllerAs);
        }
    }
}