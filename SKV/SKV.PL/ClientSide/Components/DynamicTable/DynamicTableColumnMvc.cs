using System;
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
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private IResponsibilityChain<DynamicTableColumnMvc> Chain { get; set; }

        #endregion

        #region Component properties

        private string ComponentName { get; set; } = default(string);
        private string ComponentTitle { get; set; } = default(string);

        private uint ComponentWidth { get; set; } = default(int);

        private bool ComponentEditable { get; set; } = default(bool);
        private bool ComponentFilterable { get; set; } = default(bool);

        private TableColumnDataType ComponentType { get; set; } = default(TableColumnDataType);

        #endregion

        #region Component setting

        public IDynamicTableColumn Name(string name) => Chain.Responsibility(() => ComponentName = name);
        public IDynamicTableColumn Title(string title) => Chain.Responsibility(() => ComponentTitle = title);

        public IDynamicTableColumn Width(uint width) => Chain.Responsibility(() => ComponentWidth = width);

        public IDynamicTableColumn Editable(bool editable) => Chain.Responsibility(() => ComponentEditable = editable);
        public IDynamicTableColumn Filterable(bool filterable) => Chain.Responsibility(() => ComponentFilterable = filterable);

        public IDynamicTableColumn Type(TableColumnDataType type) => Chain.Responsibility(() => ComponentType = type);

        #endregion

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentName, nameof(ComponentName));
            Tools.ThrowIfNull(ComponentTitle, nameof(ComponentTitle));
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(DynamicTableColumnMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentName), ComponentName);
            template.SetParameter(nameof(ComponentTitle), ComponentTitle);
            template.SetParameter(nameof(ComponentWidth), ComponentWidth.ToString());

            template.SetParameter(nameof(ComponentType), Enum.GetName(typeof(TableColumnDataType), ComponentType));

            template.SetParameter(nameof(ComponentEditable), ComponentEditable.ToString().ToLower());
            template.SetParameter(nameof(ComponentFilterable), ComponentFilterable.ToString().ToLower());

            return template.Render();
        }
    }
}