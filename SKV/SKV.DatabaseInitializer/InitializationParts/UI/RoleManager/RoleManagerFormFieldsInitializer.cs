using SKV.ML.Concrete;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.Concrete.Model.CommonModel;

using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;

using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Components.VerticalFormField;

using Config = SKV.Configuration;

namespace SKV.DatabaseInitializer.InitializationParts.UI.RoleManager
{
    public class RoleManagerFormFieldsInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public RoleManagerFormFieldsInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            var modelPath = Config.AngularControllerDefaults.CurrentRole;
            var controllerAs = Config.AngularControllerAs.RoleManagerControllerAs;

            InitializeRoleProfileFields(modelPath, controllerAs);

            Context.SaveChanges();
        }

        private void InitializeRoleProfileFields(string modelPath, string controllerAs)
        {
            var nameField = new VerticalFormFieldMvc().Field<UserRole>(m => m.Name)
                                                      .Attributes(new { type = "text" })
                                                      .ModelPath(modelPath)
                                                      .ControllerName(controllerAs)
                                                      .Icon("glyphicon glyphicon-user form-control-feedback")
                                                      .Type(UIFieldType.Input);

            var pageNameField = new VerticalFormFieldMvc().Field<UserRole>("Pages")
                                                          .ModelPath(modelPath)
                                                          .ControllerName(controllerAs)
                                                          .Icon("glyphicon glyphicon-user form-control-feedback")
                                                          .ButtonTitleFieldPath(nameof(Page.Name)).Type(UIFieldType.Dropdown);

            var permissionsField = new VerticalFormFieldMvc().Field<UserRole>(m => m.Permissions)
                                                             .ModelPath(modelPath)
                                                             .ControllerName(controllerAs)
                                                             .Icon("glyphicon glyphicon-user form-control-feedback")
                                                             .ButtonTitleFieldPath(nameof(UserPermission.Name))
                                                             .Type(UIFieldType.SelectListBox);

            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.RoleManager_Name_Field, nameField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.RoleManager_PageInstance_Name_Field, pageNameField));
            Context.UIComponentData.Add(Tools.CreateUIComponentData(UIComponentKey.RoleManager_Permissions, permissionsField));
        }
    }
}
