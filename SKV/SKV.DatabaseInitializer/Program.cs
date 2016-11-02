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
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Components.VerticalFormField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            db.UIMenuItems.Add(new UIMenuItem() { Id = 7, Location = 4, ParentId = 1, Name = "RoleManager" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 8, Location = 5, ParentId = 1, Name = "UserManager", Controller = "App/UserManager", Action = "Index" });

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

            #region UIData
            var ssetings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var current_user = "CurrentUser";
            #region UserProfile

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_UserName_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<User>(m => m.UserName).Type(UIFieldType.Input).ExportToModel(), 
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_Email_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("icon-mail-3 form-control-feedback")
                                                                                       .Field<User>(m => m.Email).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_UserProfile_Name_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<User>(m => m.Profile.Name).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_PhoneNumber_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-phone form-control-feedback")
                                                                                       .Field<User>(m => m.PhoneNumber).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_UserProfile_AsteriskId,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-certificate form-control-feedback")
                                                                                       .Field<User>(m => m.Profile.AsteriskId).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserManager_Roles,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().ButtonClickFunctionName("AddRole")
                                                                                       .Field<User>("Roles").Type(UIFieldType.Buttons).ExportToModel(),
                                                                                       ssetings)
            });

            #endregion

            #region UserCreating

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_UserName_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.UserName).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Email_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("icon-mail-3 form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.Email).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Initials_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.Initials).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_PhoneNumber_Field,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-phone form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.PhoneNumber).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_AsteriskId,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "text" }).ModelPath(current_user)
                                                                                       .Icon("glyphicon glyphicon-certificate form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.AsteriskId).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Roles,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().ButtonClickFunctionName("AddRole").ModelPath(current_user)
                                                                                       .Field<UserCreatingViewModel>("Roles").Type(UIFieldType.Buttons).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_Password,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(current_user)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.Password).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.UserCreating_PasswordConfirm,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(current_user)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserCreatingViewModel>(m => m.ConfirmPassword).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            #endregion

            #region PasswordChanging

            var pc_model = "PasswordChangingModel";

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.PasswordChanging_OldPassword,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(pc_model)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserPasswordChangingViewModel>(m => m.OldPassword).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.PasswordChanging_NewPassword,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(pc_model)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserPasswordChangingViewModel>(m => m.NewPassword).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            db.UIComponentData.Add(new UIComponentData()
            {
                Id = (int)UIComponentKey.PasswordChanging_NewPasswordConfirm,
                TypeName = typeof(VerticalFormFieldMvc).Name,
                SerializedData = JsonConvert.SerializeObject(new VerticalFormFieldMvc().Attributes(new { type = "password" }).ModelPath(pc_model)
                                                                                       .Icon("icon-keyboard form-control-feedback")
                                                                                       .Field<UserPasswordChangingViewModel>(m => m.NewPasswordConfirm).Type(UIFieldType.Input).ExportToModel(),
                                                                                       ssetings)
            });

            #endregion

            #endregion

            db.SaveChanges();

            db.Dispose();
        }
    }
}
