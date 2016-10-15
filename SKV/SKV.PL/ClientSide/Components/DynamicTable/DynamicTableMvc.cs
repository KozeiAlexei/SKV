using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableMvc : IDynamicTable
    {
        #region Component constructor

        public DynamicTableMvc()
        {
            Model = new DynamicTableModelMvc();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private DynamicTableModelMvc Model { get; set; }
        private IResponsibilityChain<DynamicTableMvc> Chain { get; set; }

        #endregion

        #region ComponentSetting

        public IDynamicTable Id(string id) => Chain.Responsibility(() => Model.Id = id);
        public IDynamicTable Title(string title) => Chain.Responsibility(() => Model.Title = title);

        public IDynamicTable Editable(bool editable) => Chain.Responsibility(() => Model.Editable = editable);
        public IDynamicTable Paginable(bool paginable, uint? page_size = null) => Chain.Responsibility(() =>
        {
            Model.PageSize = page_size.GetValueOrDefault(ClientSideConfiguration.DefaultTablePageSize);
            Model.Paginable = paginable;
        });
        public IDynamicTable Filterable(bool filterable) => Chain.Responsibility(() => Model.Filterable = filterable);

        public IDynamicTable AngularTableSettingsFactoryName(string name) => 
            Chain.Responsibility(() => Model.AngularTableSettingsFactoryName = name);

        public IDynamicTable AngularDynamicTableControllerName(string name) =>
            Chain.Responsibility(() => Model.AngularDynamicTableControllerName = name);

        public IDynamicTable AngularDynamicTableActionsController(string name) =>
            Chain.Responsibility(() => Model.AngularDynamicTableActionsController = name);

        public IDynamicTable AngularDynamicTableActionsControllerName(string name) =>
            Chain.Responsibility(() => Model.AngularDynamicTableActionsControllerName = name);

        public IDynamicTable Body(Action<IContainer> body) => Chain.Responsibility(() => body(Model.Body));
        public IDynamicTable Logic(Action<IContainer> logic) => Chain.Responsibility(() => logic(Model.Logic));
        public IDynamicTable Columns(Action<IContainer> columns) => Chain.Responsibility(() => columns(Model.Columns));
        public IDynamicTable RowActions(Action<IContainer> actions) => Chain.Responsibility(() => actions(Model.RowActions));
        public IDynamicTable TopManagmentPanel(Action<IContainer> panel) => Chain.Responsibility(() => panel(Model.TopManagmentPanel));
        public IDynamicTable BottomManagmentPanel(Action<IContainer> panel) => Chain.Responsibility(() => panel(Model.BottomManagmentPanel));

        #endregion


        public MvcHtmlString Render() => new ComponentRenderer(nameof(DynamicTableMvc)).Render(Model);
    }
}