using System.Web.Mvc;

namespace SKV.PL.ClientSide.Concrete
{
    public class Linker
    {
        public static MvcHtmlString GetService(string service_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Services/{ service_name }Service.js\"></script>");

        public static MvcHtmlString GetServiceExt(string service_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Services/{ service_name }.js\"></script>");

        public static MvcHtmlString GetDirective(string directive_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Directives/{ directive_name }.js\"></script>");

        public static MvcHtmlString DynamicTableModule() =>
            MvcHtmlString.Create("<script src=\"/Infrastructure/DynamicTable/DynamicTableController.js\"></script>");
    }
}