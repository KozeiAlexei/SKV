using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.Helpers
{
    public class ClientSide
    {
        public static IHtmlString GetService(string service_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Services/{ service_name }Service.js\"></script>");

        public static IHtmlString GetDirective(string directive_name) =>
            MvcHtmlString.Create($"<script src=\"/Infrastructure/Directives/{ directive_name }.js\"></script>");

        public static IHtmlString DynamicTableModule() =>
            MvcHtmlString.Create("<script src=\"/Infrastructure/DynamicTable/DynamicTableController.js\"></script>");

    }
}