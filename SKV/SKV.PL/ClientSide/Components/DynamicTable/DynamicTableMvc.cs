using System;
using System.Text;
using System.Web.Mvc;

using Ninject;
using Ninject.Parameters;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Concrete;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableMvc : IDynamicTable
    {
        public DynamicTableMvc()
        {
            Chain = (IResponsibilityChain<DynamicTableMvc>)PLDependencyResolver.Kernel.Get(typeof(IResponsibilityChain<DynamicTableMvc>),
                     new ConstructorArgument("obj", this));
        }

        private IResponsibilityChain<DynamicTableMvc> Chain { get; set; }

        #region Component properties

        public string ComponentAngularApplicationName { get; set; }
        public string ComponentAngularTableSettinsFactoryName { get; set; }
        public string ComponentAngularDynamicTableControllerName { get; set; }
        public string ComponentAngularDynamicTableActionsControllerName { get; set; }

        public string ComponentId { get; set; }
        public string ComponentTitle { get; set; }

        public bool ComponentEditable { get; set; }
        public bool ComponentFilterable { get; set; }

        public IContent ComponentColumns { get; set; } = PLDependencyResolver.Kernel.Get<IContent>();

        #endregion

        #region ComponentSetting

        public IDynamicTable Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public IDynamicTable Title(string title) => Chain.Responsibility(() => ComponentTitle = title);

        public IDynamicTable Editable(bool editable) => Chain.Responsibility(() => ComponentEditable = editable);
        public IDynamicTable Filterable(bool filterable) => Chain.Responsibility(() => ComponentFilterable = filterable);

        public IDynamicTable AngularApplicationName(string name) => 
            Chain.Responsibility(() => ComponentAngularApplicationName = name);

        public IDynamicTable AngularTableSettinsFactoryName(string name) => 
            Chain.Responsibility(() => ComponentAngularTableSettinsFactoryName = name);

        public IDynamicTable AngularDynamicTableControllerName(string name) =>
            Chain.Responsibility(() => ComponentAngularDynamicTableControllerName = name);

        public IDynamicTable AngularDynamicTableActionsControllerName(string name) =>
            Chain.Responsibility(() => ComponentAngularDynamicTableActionsControllerName = name);

        public IDynamicTable Columns(Action<IContent> columns) => Chain.Responsibility(() => columns(ComponentColumns));


        #endregion

        #region Private methods

        private string CreateTableSettingsFactory()
        {
            var builder = new StringBuilder();

            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine($"angular.module('{ ComponentAngularApplicationName }').factory('{ ComponentAngularTableSettinsFactoryName }', function()" + " {");
            builder.AppendLine("return {");
            builder.AppendLine("GetTableSettings: function() {");
            builder.AppendLine("return {");
            builder.AppendLine("Columns: [");

            foreach (var col in ComponentColumns.Collection)
                builder.AppendLine($"{ col.Render() }, ");

            builder.AppendLine("] } }");

            //Add other functions

            builder.AppendLine("}});</script>");

            return builder.ToString();
        }

        #endregion

        public MvcHtmlString Render()
        {
            var builder = new StringBuilder();

            builder.AppendLine(CreateTableSettingsFactory());

            builder.AppendLine();
            builder.AppendLine($"<any ng-controller=\"DynamicTableController as { ComponentAngularDynamicTableControllerName }\">");
            builder.AppendLine($"<any ng-controller=\"UserManagerController as { ComponentAngularDynamicTableActionsControllerName }\">");
            builder.AppendLine("<dynamic-table></dynamic-table></any></any>");

            return MvcHtmlString.Create(builder.ToString());
        }

    }
}