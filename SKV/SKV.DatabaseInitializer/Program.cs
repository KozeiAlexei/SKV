using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using SKV.BLL.Identity;
using SKV.DAL;
using SKV.DAL.Concrete.EntityFramework;
using SKV.ML.Concrete;
using SKV.ML.Concrete.Model.CommonModel;
using SKV.ML.Concrete.Model.UIModel;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.ViewModels.Account;
using SKV.PL;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Components.VerticalFormField;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Config = SKV.Configuration;

namespace SKV.DatabaseInitializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseContext();

            db.UICulture.Add(new UICulture() { Name = "Русский", Culture = "ru-RU" });
            db.UICulture.Add(new UICulture() { Name = "English", Culture = "en-US" });



            db.UIMenuItems.Add(new UIMenuItem() { Id = 1, Location = 1, ParentId = DALStaticData.UIMenuItemTopParentId, Name = "Administration", IconClass = "icon-home-3" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 2, Location = 2, ParentId = DALStaticData.UIMenuItemTopParentId, Name = "Operator", IconClass = "icon-home-3" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 3, Location = 3, ParentId = DALStaticData.UIMenuItemTopParentId, Name = "Reports", IconClass = "icon-home-3" });

            db.UIMenuItems.Add(new UIMenuItem() { Id = 4, Location = 1, ParentId = 1, Name = "SystemSettings" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 5, Location = 2, ParentId = 1, Name = "MenuSettings" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 6, Location = 3, ParentId = 1, Name = "EventJournal" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 7, Location = 4, ParentId = 1, Name = "RoleManager", Controller = "Administration/Security/RoleManager", Action = "Index" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 8, Location = 5, ParentId = 1, Name = "UserManager", Controller = "Administration/Security/UserManager", Action = "Index" });

            db.UIMenuItems.Add(new UIMenuItem() { Id = 9, Location = 1, ParentId = 2, Name = "MonitoringSystem" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 10, Location = 2, ParentId = 2, Name = "Exchange" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 11, Location = 3, ParentId = 2, Name = "Correction" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 12, Location = 4, ParentId = 2, Name = "Inventarisation" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 13, Location = 5, ParentId = 2, Name = "MoneyTransfer" });

            db.UIMenuItems.Add(new UIMenuItem() { Id = 14, Location = 1, ParentId = 3, Name = "CashRemainsReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 15, Location = 2, ParentId = 3, Name = "InventarisationReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 16, Location = 3, ParentId = 3, Name = "ProfitReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 17, Location = 3, ParentId = 3, Name = "DealReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 18, Location = 3, ParentId = 3, Name = "CanceledOrdersReport" });


            db.SaveChanges();

            db.SystemSettings.Add(new SystemSettings()
            {
                DefaultCultureId = 1
            });

            db.SaveChanges();

            var user_manager = new UserManager<User>(new UserStore<User>(db));
            var user = new User()
            {
                Email = string.Empty,
                UserName = "Admin",
                Profile = new UserProfile()
                {
                    Name = "Администратор",
                    LastLoginDate = DateTime.Now,
                    RegistrationDate = DateTime.Now,
                }
            };


            var result = user_manager.CreateAsync(user, "Evolution1_").Result;

            db.Pages.Add(new Page() { Name = "Главная", URL = "Home/Index" });
            db.Pages.Add(new Page() { Name = "Менеджер пользователей", URL = "Home/Index" });
            db.Pages.Add(new Page() { Name = "Менеджер ролей", URL = "Home/Index" });
            db.Pages.Add(new Page() { Name = "Тест1", URL = "Home/Index" });
            db.Pages.Add(new Page() { Name = "Тест2", URL = "Home/Index" });
            db.SaveChanges();


            var role_manager = new RoleManager<UserRole>(new RoleStore<UserRole>(db));
            var role = new UserRole()
            {
                DefaultRoleCode = DefaultRole.Admin,
                DefaultPageId = 1,
                Name = "Admin",
            };
            var role_result = role_manager.Create(role);

            var perm1 = new UserPermission() { Name = "Показ пункта меню \"Администрирование\"", Code = UserPermissionCode.ShowAdministrationMenuItem };
            var perm2 = new UserPermission() { Name = "Показ пункта меню \"Оператор\"", Code = UserPermissionCode.ShowOperatorMenuItem };

            db.UserPermissions.Add(perm1);
            db.UserPermissions.Add(perm2);

            db.SaveChanges();

            role = db.Roles.OfType<UserRole>().Include(e => e.Permissions).Where(e => e.DefaultRoleCode == DefaultRole.Admin).First();
            role.Permissions.Add(perm1);
            role.Permissions.Add(perm2);


            #region UIData
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var current_user = "CurrentUser";
            var currentRole = "CurrentRole";
            #region UserProfile

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_UserName_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<User>(m => m.UserName).Type(UIFieldType.Input).ExportToModel(), 
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_Email_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-mail-3 form-control-feedback")
                                                                                       .Field<User>(m => m.Email).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_UserProfile_Name_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<User>(m => m.Profile.Name).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_PhoneNumber_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-phone form-control-feedback")
                                                                                       .Field<User>(m => m.PhoneNumber).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_UserProfile_AsteriskId,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-certificate form-control-feedback")
                                                                                       .Field<User>(m => m.Profile.AsteriskId).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_Roles,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().ButtonClickFunctionName("AddRole").ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Field<User>("Roles").Type(UIFieldType.Buttons).ButtonTitleFieldPath(nameof(UserRole.Name)).ExportToModel(),
                                                                                       settings)
            });

            #endregion

            #region UserCreating

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_UserName_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.UserName).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Email_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-mail-3 form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.Email).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Initials_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.Initials).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_PhoneNumber_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-phone form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.PhoneNumber).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_AsteriskId,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-certificate form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.AsteriskId).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Roles,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().ButtonClickFunctionName("AddRole").ButtonTitleFieldPath(nameof(UserRole.Name)).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Field<UserCreatingViewModel>("Roles").Type(UIFieldType.Buttons).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Password,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.Password).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_PasswordConfirm,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(current_user).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.ConfirmPassword).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            #endregion

            #region PasswordChanging

            var pc_model = "PasswordChangingModel";

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.PasswordChanging_OldPassword,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(pc_model).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserPasswordChangingViewModel>(m => m.OldPassword).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.PasswordChanging_NewPassword,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(pc_model).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserPasswordChangingViewModel>(m => m.NewPassword).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.PasswordChanging_NewPasswordConfirm,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(pc_model).ControllerName(Config.AngularControllerAs.UserManagerControllerAs)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserPasswordChangingViewModel>(m => m.NewPasswordConfirm).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            #endregion

            #region RoleMainSettings

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.RoleManager_Name_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(currentRole).ControllerName(Config.AngularControllerAs.RoleManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserRole>(m => m.Name).Type(UIFieldType.Input).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.RoleManager_PageInstance_Name_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().ModelPath(currentRole).ControllerName(Config.AngularControllerAs.RoleManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserRole>("Pages")
                                                                                       .ButtonTitleFieldPath(nameof(Page.Name)).Type(UIFieldType.Dropdown).ExportToModel(),
                                                                                       settings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.RoleManager_Permissions,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().ModelPath(currentRole).ControllerName(Config.AngularControllerAs.RoleManagerControllerAs)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserRole>(m => m.Permissions).ButtonTitleFieldPath(nameof(UserPermission.Name))
                                                                                       .Type(UIFieldType.Dropdown).ExportToModel(),
                                                                                       settings)
            });

            #endregion


            #endregion

            db.SaveChanges();

            db.Dispose();
        }
    }
}
