using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableMvc : IDynamicTable
    {
        public DynamicTableMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this);

            ComponentBody = Tools.CreateContainer();
            ComponentLogic = Tools.CreateContainer();
            ComponentColumns = Tools.CreateContainer();

            ComponentAngularApplicationName = CRMConfiguration.AngularApplicationName;
            ComponentAngularDynamicTableControllerName = CRMConfiguration.AngularDynamicTableControllerName;
        }

        private IResponsibilityChain<DynamicTableMvc> Chain { get; set; }

        #region Component properties

        private string ComponentAngularApplicationName { get; set; }
        private string ComponentAngularTableSettingsFactoryName { get; set; }
        private string ComponentAngularDynamicTableControllerName { get; set; }
        private string ComponentAngularDynamicTableActionsController { get; set; }
        private string ComponentAngularDynamicTableActionsControllerName { get; set; }

        private string ComponentId { get; set; }
        private string ComponentTitle { get; set; }

        private bool ComponentEditable { get; set; }
        private bool ComponentFilterable { get; set; }

        private IContainer ComponentBody { get; set; }
        private IContainer ComponentLogic { get; set; }
        private IContainer ComponentColumns { get; set; }

        #endregion

        #region ComponentSetting

        public IDynamicTable Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public IDynamicTable Title(string title) => Chain.Responsibility(() => ComponentTitle = title);

        public IDynamicTable Editable(bool editable) => Chain.Responsibility(() => ComponentEditable = editable);
        public IDynamicTable Filterable(bool filterable) => Chain.Responsibility(() => ComponentFilterable = filterable);

        public IDynamicTable AngularTableSettingsFactoryName(string name) => 
            Chain.Responsibility(() => ComponentAngularTableSettingsFactoryName = name);

        public IDynamicTable AngularDynamicTableControllerName(string name) =>
            Chain.Responsibility(() => ComponentAngularDynamicTableControllerName = name);

        public IDynamicTable AngularDynamicTableActionsController(string name) =>
            Chain.Responsibility(() => ComponentAngularDynamicTableActionsController = name);

        public IDynamicTable AngularDynamicTableActionsControllerName(string name) =>
            Chain.Responsibility(() => ComponentAngularDynamicTableActionsControllerName = name);

        public IDynamicTable Body(Action<IContainer> body) => Chain.Responsibility(() => body(ComponentBody));
        public IDynamicTable Logic(Action<IContainer> logic) => Chain.Responsibility(() => logic(ComponentLogic));
        public IDynamicTable Columns(Action<IContainer> columns) => Chain.Responsibility(() => columns(ComponentColumns));

        #endregion

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentAngularApplicationName, nameof(ComponentAngularApplicationName));
            Tools.ThrowIfNull(ComponentAngularTableSettingsFactoryName, nameof(ComponentAngularTableSettingsFactoryName));
            Tools.ThrowIfNull(ComponentAngularDynamicTableControllerName, nameof(ComponentAngularDynamicTableControllerName));
            Tools.ThrowIfNull(ComponentAngularDynamicTableActionsController, nameof(ComponentAngularDynamicTableActionsController));
            Tools.ThrowIfNull(ComponentAngularDynamicTableActionsControllerName, nameof(ComponentAngularDynamicTableActionsControllerName));
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(DynamicTableMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentAngularApplicationName), ComponentAngularApplicationName);
            template.SetParameter(nameof(ComponentAngularTableSettingsFactoryName), ComponentAngularTableSettingsFactoryName);
            template.SetParameter(nameof(ComponentAngularDynamicTableControllerName), ComponentAngularDynamicTableControllerName);
            template.SetParameter(nameof(ComponentAngularDynamicTableActionsController), ComponentAngularDynamicTableActionsController);
            template.SetParameter(nameof(ComponentAngularDynamicTableActionsControllerName), ComponentAngularDynamicTableActionsControllerName);

            template.SetParameter(nameof(ComponentBody), () => ComponentBody.Render());
            template.SetParameter(nameof(ComponentLogic), () => ComponentLogic.Render());
            template.SetParameter(nameof(ComponentColumns), () => ComponentColumns.Render());

            return template.Render();
        }
    }
}