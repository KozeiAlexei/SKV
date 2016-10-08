using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableColumnMvc : IDynamicTableColumn
    {
        #region Constructor

        public DynamicTableColumnMvc()
        {
            Model = new DynamicTableColumnModelMvc();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private DynamicTableColumnModelMvc Model { get; set; }
        private IResponsibilityChain<DynamicTableColumnMvc> Chain { get; set; }

        #endregion

        #region Component setting

        public IDynamicTableColumn Name(string name) => Chain.Responsibility(() => Model.Name = name);
        public IDynamicTableColumn Title(string title) => Chain.Responsibility(() => Model.Title = title);

        public IDynamicTableColumn Width(uint width) => Chain.Responsibility(() => Model.Width = width);

        public IDynamicTableColumn Editable(bool editable) => Chain.Responsibility(() => Model.Editable = editable);
        public IDynamicTableColumn Filterable(bool filterable) => Chain.Responsibility(() => Model.Filterable = filterable);

        public IDynamicTableColumn Type(TableColumnDataType type) => Chain.Responsibility(() => Model.Type = type);

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(DynamicTableColumnMvc)).Render(Model);
    }
}