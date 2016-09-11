using System;
using System.Web.Mvc;

using Ninject;
using Ninject.Parameters;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableColumnMvc : IDynamicTableColumn
    {
        public DynamicTableColumnMvc()
        {
            Chain = (IResponsibilityChain<DynamicTableColumnMvc>)PLDependencyResolver.Kernel.Get(typeof(IResponsibilityChain<DynamicTableColumnMvc>),
                     new ConstructorArgument("obj", this));
        }

        private IResponsibilityChain<DynamicTableColumnMvc> Chain { get; set; }

        #region Component properties

        public string ComponentName { get; set; } = default(string);
        public string ComponentTitle { get; set; } = default(string);

        public uint ComponentWidth { get; set; } = default(int);

        public bool ComponentEditable { get; set; } = default(bool);
        public bool ComponentFilterable { get; set; } = default(bool);

        public TableColumnDataType ComponentType { get; set; } = default(TableColumnDataType);

        #endregion

        #region Component setting

        public IDynamicTableColumn Name(string name) => Chain.Responsibility(() => ComponentName = name);
        public IDynamicTableColumn Title(string title) => Chain.Responsibility(() => ComponentTitle = title);

        public IDynamicTableColumn Width(uint width) => Chain.Responsibility(() => ComponentWidth = width);

        public IDynamicTableColumn Editable(bool editable) => Chain.Responsibility(() => ComponentEditable = editable);
        public IDynamicTableColumn Filterable(bool filterable) => Chain.Responsibility(() => ComponentFilterable = filterable);

        public IDynamicTableColumn Type(TableColumnDataType type) => Chain.Responsibility(() => ComponentType = type);

        #endregion

        public MvcHtmlString Render()
        {
            var column_name = $"Name: \"{ ComponentName }\", \n";
            var column_title = $"Title: \"{ ComponentTitle }\", \n";
            var column_width = $"Width: { ComponentWidth }, \n";

            var column_editable = $"IsEditable: { ComponentEditable.ToString().ToLower() }, \n";
            var column_filterable = $"Filter: { ComponentFilterable.ToString().ToLower() }, \n";

            var column_type = $"DataType: \"{ Enum.GetName(typeof(TableColumnDataType), ComponentType)}\" \n";

            return MvcHtmlString.Create("{" + $"{ column_name } { column_title } { column_width } {column_editable} {column_filterable} { column_type }" + "}");
        }
    }
}