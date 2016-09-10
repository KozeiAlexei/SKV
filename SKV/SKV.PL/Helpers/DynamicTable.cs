using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Helpers
{
    public enum TableColumnDataType
    {
        Text,
        Number,
        Actions,
        Dropdown,
        Currency,
        Component
    }

    public class TableColumn
    {
        public TableColumn()
        {
            Chain = new ResponsibilityChain<TableColumn>(this);
        }

        private ResponsibilityChain<TableColumn> Chain { get; set; }

        private string ColumnName { get; set; } = default(string);
        private string ColumnTitle { get; set; } = default(string);

        private int ColumnWidth { get; set; } = default(int);

        private bool ColumnEditable { get; set; } = default(bool);
        private bool ColumnFilterable { get; set; } = default(bool);

        private TableColumnDataType ColumnType { get; set; } = default(TableColumnDataType);

        public TableColumn Name(string name) => Chain.Responsibility(() => ColumnName = name);
        public TableColumn Title(string title) => Chain.Responsibility(() => ColumnTitle = title);

        public TableColumn Width(int width) => Chain.Responsibility(() => ColumnWidth = width);

        public TableColumn Editable(bool editable) => Chain.Responsibility(() => ColumnEditable = editable);
        public TableColumn Filterable(bool filterable) => Chain.Responsibility(() => ColumnFilterable = filterable);

        public TableColumn Type(TableColumnDataType type) => Chain.Responsibility(() => ColumnType = type);


        internal string Build()
        {
            var column_name = $"Name: \"{ ColumnName }\", \n";
            var column_title = $"Title: \"{ ColumnTitle }\", \n";
            var column_width = $"Width: { ColumnWidth }, \n";

            var column_editable = $"IsEditable: { ColumnEditable.ToString().ToLower() }, \n";
            var column_filterable = $"Filter: { ColumnFilterable.ToString().ToLower() }, \n";

            var column_type = $"DataType: \"{ Enum.GetName(typeof(ColumnDataType), ColumnType)}\" \n";

            return "{" + $"{ column_name } { column_title } { column_width } {column_editable} {column_filterable} { column_type }" + "}";
        }
    }

    public class TableColumnsCollection
    {
        public List<TableColumn> Columns { get; } = new List<TableColumn>();

        public TableColumn Create()
        {
            var column = new TableColumn();

            Columns.Add(column);
            return column;
        }
    }

    public class DynamicTable
    {
        public DynamicTable()
        {
            Chain = new ResponsibilityChain<DynamicTable>(this);
        }

        private ResponsibilityChain<DynamicTable> Chain { get; set; }

        private string TableName { get; set; }
        private string TableControllerName { get; set; }
        private string TableActionsControllerName { get; set; }

        private string ApplicationName { get; set; }
        private string TableSettingsFactoryName { get; set; }

        private TableColumnsCollection TableColumns { get; } = new TableColumnsCollection();

        public static DynamicTable Create() => new DynamicTable();

        public DynamicTable Name(string name) => Chain.Responsibility(() => TableName = name);
        public DynamicTable ControllerName(string name) => Chain.Responsibility(() => TableControllerName = name);
        public DynamicTable ActionsControllerName(string name) => Chain.Responsibility(() => TableActionsControllerName = name);

        public DynamicTable SettingsFactoryName(string name) => Chain.Responsibility(() => TableSettingsFactoryName = name);
        public DynamicTable AngularApplicationName(string name) => Chain.Responsibility(() => ApplicationName = name);

        public DynamicTable Columns(Action<TableColumnsCollection> generator) =>
            Chain.Responsibility(() => generator(TableColumns));

        public IHtmlString Build()
        {
            var builder = new StringBuilder();

            builder.AppendLine(CreateTableSettingsFactory(ApplicationName, TableSettingsFactoryName));

            builder.AppendLine();
            builder.AppendLine($"<widget title=\"{ TableName }\">");
            builder.AppendLine($"<any ng-controller=\"DynamicTableController as { TableControllerName }\">");
            builder.AppendLine($"<any ng-controller=\"UserManagerController as { TableActionsControllerName }\">");
            builder.AppendLine("<dynamic-table></dynamic-table></any></any></widget>");

            return MvcHtmlString.Create(builder.ToString());
        }

        private string CreateTableSettingsFactory(string app_name, string factory_name)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine($"angular.module('{ app_name }').factory('{ factory_name }', function()" + " {");
            builder.AppendLine("return {");
            builder.AppendLine("GetTableSettings: function() {");
            builder.AppendLine("return {");
            builder.AppendLine("Columns: [");

            foreach (var col in TableColumns.Columns)
                builder.AppendLine($"{ col.Build() }, ");

            builder.AppendLine("] } }");

            //Add other functions

            builder.AppendLine("}});</script>");

            return builder.ToString();
        }
    }

    public class ResponsibilityChain<TSubject> where TSubject: class
    {
        private TSubject @object = default(TSubject);

        public ResponsibilityChain(TSubject obj)
        {
            @object = obj;
        }

        public TSubject Responsibility(Action resp)
        {
            resp();
            return @object;
        }
    }
}