using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Helpers
{
    public enum ColumnDataType
    {
        Text,
        Number,
        Actions,
        Dropdown,
        Currency,
        Component
    }

    public class ClientSide
    {
        public class TableSettings
        {
            public string CreateColumn(string name, string title, int width, bool filterable, ColumnDataType type, bool editable)
            {
                var column_name = $"Name: \"{ name }\", \n";
                var column_title = $"Title: \"{ title }\", \n";
                var column_width = $"Width: { width }, \n";

                var column_editable = $"IsEditable: { editable.ToString().ToLower() }, \n";
                var column_filterable = $"Filter: { filterable.ToString().ToLower() }, \n";

                var column_type = $"DataType: \"{ Enum.GetName(typeof(ColumnDataType), type)}\" \n";

                return "{" + $"{ column_name } { column_title } { column_width } {column_editable} {column_filterable} { column_type }" + "}";
            }

            public static IHtmlString CreateTableSettingsFactory(string app_name, string factory_name, Expression<Func<TableSettings, string>>[] column_generators)
            {
                var builder = new StringBuilder();

                builder.AppendLine("<script type=\"text/javascript\">");
                builder.AppendLine($"angular.module('{ app_name }').factory('{ factory_name }', function()" + " {");
                builder.AppendLine("return {");
                builder.AppendLine("GetTableSettings: function() {");
                builder.AppendLine("return {");
                builder.AppendLine("Columns: [");

                foreach(var gen in column_generators)
                    builder.AppendLine($"{ gen.Compile().Invoke(new TableSettings()) }, ");

                builder.AppendLine("] } }");

                //Add other functions

                builder.AppendLine("}});</script>");

                return MvcHtmlString.Create(builder.ToString());
            }
        }

        public static IHtmlString GetService(string service_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Services/{ service_name }Service.js\"></script>");

        public static IHtmlString GetDirective(string directive_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Directives/{ directive_name }.js\"></script>");

        public static IHtmlString DynamicTableModule() =>
            MvcHtmlString.Create("<script src=\"/Infrastructure/DynamicTable/DynamicTableController.js\"></script>");

    }
}