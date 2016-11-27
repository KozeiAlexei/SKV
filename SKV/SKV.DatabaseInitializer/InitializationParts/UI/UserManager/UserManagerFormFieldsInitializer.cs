using SKV.ML.Concrete;
using SKV.ML.ViewModels.Account;
using SKV.ML.Concrete.Model.UserModel;

using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;

using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Components.VerticalFormField;

using Config = SKV.Configuration;

namespace SKV.DatabaseInitializer.InitializationParts.UI.UserManager
{
    public class UserManagerFormFieldsInitializer: IEntityInitializer
    {
        private DatabaseContext Context { get; }

        public UserManagerFormFieldsInitializer(DatabaseContext db)
        {
            Context = db;
        }

        public void Initialize()
        {
            var usermodelPath = Config.AngularControllerDefaults.CurrentUser;
            var userManagerControllerAs = Config.AngularControllerAs.UserManagerControllerAs;

            var passwordChangingModelPath = Config.AngularControllerDefaults.PasswordChanging;

            InitializeUserProfileTabFields(usermodelPath, userManagerControllerAs);
            InitializeUserCreatingTabFields(usermodelPath, userManagerControllerAs);
            InitializePasswordChangingTabFields(passwordChangingModelPath, userManagerControllerAs);

            Context.SaveChanges();
        }

        private void InitializeUserProfileTabFields(string modelPath, string controllerAs)
        {
            var userNameField = new VerticalFormFieldMvc().Field<User>(m => m.UserName)
                                                          .Attributes(new { type = "text" })
                                                          .ModelPath(modelPath)
                                                          .ControllerName(controllerAs)
                                                          .Icon("glyphicon glyphicon-user form-control-feedback")
                                                          .Type(UIFieldType.Input);

            var emailField = new VerticalFormFieldMvc().Field<User>(m => m.Email)
                                                       .Attributes(new { type = "text" })
                                                       .ModelPath(modelPath)
                                                       .ControllerName(controllerAs)
                                                       .Icon("icon-mail-3 form-control-feedback")
                                                       .Type(UIFieldType.Input);

            var userProfileNameField = new VerticalFormFieldMvc().Field<User>(m => m.Profile.Name)
                                                                 .Attributes(new { type = "text" })
                                                                 .ModelPath(modelPath)
                                                                 .ControllerName(controllerAs)
                                                                 .Icon("glyphicon glyphicon-user form-control-feedback")
                                                                 .Type(UIFieldType.Input);

            var phoneNumberField = new VerticalFormFieldMvc().Field<User>(m => m.PhoneNumber)
                                                             .Attributes(new { type = "text" })
                                                             .ModelPath(modelPath)
                                                             .ControllerName(controllerAs)
                                                             .Icon("glyphicon glyphicon-phone form-control-feedback")
                                                             .Type(UIFieldType.Input);


            var userProfileAsteriskIdField = new VerticalFormFieldMvc().Field<User>(m => m.Profile.AsteriskId)
                                                                       .Attributes(new { type = "text" })
                                                                       .ModelPath(modelPath)
                                                                       .ControllerName(controllerAs)
                                                                       .Icon("glyphicon glyphicon-certificate form-control-feedback")
                                                                       .Type(UIFieldType.Input);

            var rolesField = new VerticalFormFieldMvc().Field<User>("Roles")
                                                       .ButtonClickFunctionName("AddRole")
                                                       .ControllerName(controllerAs)
                                                       .Type(UIFieldType.Buttons)
                                                       .ButtonTitleFieldPath(nameof(UserRole.Name));

            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserManager_UserName_Field, userNameField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserManager_Email_Field, emailField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserManager_UserProfile_Name_Field, userProfileNameField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserManager_PhoneNumber_Field, phoneNumberField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserManager_UserProfile_AsteriskId, userProfileAsteriskIdField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserManager_Roles, rolesField));
        }

        private void InitializeUserCreatingTabFields(string modelPath, string controllerAs)
        {
            var userNameField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.UserName)
                                                          .Attributes(new { type = "text" })
                                                          .ModelPath(modelPath)
                                                          .ControllerName(controllerAs)
                                                          .Icon("glyphicon glyphicon-user form-control-feedback")
                                                          .Type(UIFieldType.Input);

            var emailField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.Email)
                                                       .Attributes(new { type = "text" })
                                                       .ModelPath(modelPath)
                                                       .ControllerName(controllerAs)
                                                       .Icon("icon-mail-3 form-control-feedback")
                                                       .Type(UIFieldType.Input);


            var initialsField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.Initials)
                                                          .Attributes(new { type = "text" })
                                                          .ModelPath(modelPath)
                                                          .ControllerName(controllerAs)                                                                                       
                                                          .Icon("glyphicon glyphicon-user form-control-feedback")                                                                                       
                                                          .Type(UIFieldType.Input);

            var phoneNumberField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.PhoneNumber)
                                                             .Attributes(new { type = "text" })
                                                             .ModelPath(modelPath)
                                                             .ControllerName(controllerAs)
                                                             .Icon("glyphicon glyphicon-phone form-control-feedback")
                                                             .Type(UIFieldType.Input);

            var asteriskIdField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.AsteriskId)
                                                            .Attributes(new { type = "text" })
                                                            .ModelPath(modelPath)
                                                            .ControllerName(controllerAs)
                                                            .Icon("glyphicon glyphicon-certificate form-control-feedback")
                                                            .Type(UIFieldType.Input);

            var rolesField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>("Roles")
                                                       .ButtonClickFunctionName("AddRole")
                                                       .ButtonTitleFieldPath(nameof(UserRole.Name))
                                                       .ModelPath(modelPath)
                                                       .ControllerName(controllerAs)
                                                       .Type(UIFieldType.Buttons);

            var passwordField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.Password)
                                                          .Attributes(new { type = "password" })
                                                          .ModelPath(modelPath)
                                                          .ControllerName(controllerAs)
                                                          .Icon("icon-keyboard form-control-feedback")
                                                          .Type(UIFieldType.Input);

            var confirmPasswordField = new VerticalFormFieldMvc().Field<UserCreatingViewModel>(m => m.ConfirmPassword)
                                                                 .Attributes(new { type = "password" })
                                                                 .ModelPath(modelPath)
                                                                 .ControllerName(controllerAs)
                                                                 .Icon("icon-keyboard form-control-feedback")
                                                                 .Type(UIFieldType.Input);

            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_UserName_Field, userNameField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_Email_Field, emailField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_Initials_Field, initialsField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_PhoneNumber_Field, phoneNumberField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_AsteriskId, asteriskIdField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_Roles, rolesField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_Password, passwordField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.UserCreating_PasswordConfirm, confirmPasswordField));
        }

        private void InitializePasswordChangingTabFields(string modelPath, string controllerAs)
        {
            var oldPasswordField = new VerticalFormFieldMvc().Field<UserPasswordChangingViewModel>(m => m.OldPassword)
                                                             .Attributes(new { type = "password" })
                                                             .ModelPath(modelPath)
                                                             .ControllerName(controllerAs)
                                                             .Icon("icon-keyboard form-control-feedback")
                                                             .Type(UIFieldType.Input);

            var newPasswordField = new VerticalFormFieldMvc().Field<UserPasswordChangingViewModel>(m => m.NewPassword)
                                                             .Attributes(new { type = "password" })
                                                             .ModelPath(modelPath)
                                                             .ControllerName(controllerAs)
                                                             .Icon("icon-keyboard form-control-feedback")
                                                             .Type(UIFieldType.Input);

            var newPasswordConfirmField = new VerticalFormFieldMvc().Field<UserPasswordChangingViewModel>(m => m.NewPasswordConfirm)
                                                               .Attributes(new { type = "password" })
                                                               .ModelPath(modelPath)
                                                               .ControllerName(controllerAs)
                                                               .Icon("icon-keyboard form-control-feedback")
                                                               .Type(UIFieldType.Input);

            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.PasswordChanging_OldPassword, oldPasswordField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.PasswordChanging_NewPassword, newPasswordField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.PasswordChanging_NewPasswordConfirm, newPasswordConfirmField));
        }
    }
}
