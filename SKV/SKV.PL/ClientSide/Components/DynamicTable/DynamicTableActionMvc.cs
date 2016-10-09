using System.Web.Mvc;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableActionMvc : IDynamicTableAction<FunctionType, string>
    {
        #region Constructor

        public DynamicTableActionMvc()
        {
            Model = new DynamicTableActionModelMvc();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private DynamicTableActionModelMvc Model { get; set; }
        private IResponsibilityChain<DynamicTableActionMvc> Chain { get; set; }

        #endregion

        #region Component setting

        public IDynamicTableAction<FunctionType, string> Id(string id) => Chain.Responsibility(() => Model.Id = id);
        public IDynamicTableAction<FunctionType, string> Icon(string icon) => Chain.Responsibility(() => Model.Icon = icon);
        public IDynamicTableAction<FunctionType, string> Title(string title) => Chain.Responsibility(() => Model.Title = title);
        public IDynamicTableAction<FunctionType, string> Class(string @class) => Chain.Responsibility(() => Model.Class = @class);

        public IDynamicTableAction<FunctionType, string> Click(FunctionType func_type, string function) =>
            Chain.Responsibility(() =>
            {
                if (func_type == FunctionType.Custom)
                    Model.Click = function;
            });

        public IDynamicTableAction<FunctionType, string> Visible(FunctionType func_type, string function) =>
            Chain.Responsibility(() =>
            {
                if (func_type == FunctionType.Custom)
                    Model.Visible = function;
            });

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(DynamicTableActionMvc)).Render(Model);
    }
}