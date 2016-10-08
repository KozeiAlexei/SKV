using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;

using System.Web.Mvc;

namespace SKV.PL.ClientSide.Components.DynamicTable
{
    public class DynamicTableActionMvc : IDynamicTableAction<FunctionType, string>
    {
        #region Constructor

        public DynamicTableActionMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private IResponsibilityChain<DynamicTableActionMvc> Chain { get; set; }

        #endregion

        #region Component properties

        private string ComponentId { get; set; }
        private string ComponentIcon { get; set; }
        private string ComponentClass { get; set; }
        private string ComponentClick { get; set; } = string.Empty;
        private string ComponentTitle { get; set; }
        private string ComponentVisibilityFunc { get; set; } = string.Empty;

        #endregion

        #region Component setting

        public IDynamicTableAction<FunctionType, string> Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public IDynamicTableAction<FunctionType, string> Icon(string icon) => Chain.Responsibility(() => ComponentIcon = icon);
        public IDynamicTableAction<FunctionType, string> Title(string title) => Chain.Responsibility(() => ComponentTitle = title);
        public IDynamicTableAction<FunctionType, string> Class(string @class) => Chain.Responsibility(() => ComponentClass = @class);

        public IDynamicTableAction<FunctionType, string> Click(FunctionType func_type, string function) =>
            Chain.Responsibility(() => FunctionSelector(func_type, function, ComponentClick));

        public IDynamicTableAction<FunctionType, string> Visible(FunctionType func_type, string function) =>
            Chain.Responsibility(() => FunctionSelector(func_type, function, ComponentVisibilityFunc));

        #endregion

        private void FunctionSelector(FunctionType func_type, string function, string container)
        {
            if (func_type == FunctionType.Custom)
                container = function;
            else
                container = $"$rootScope.ctrl.{ function }"; //Доработать
        }

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentIcon, nameof(ComponentIcon));
            Tools.ThrowIfNull(ComponentTitle, nameof(ComponentTitle));
            Tools.ThrowIfNull(ComponentClass, nameof(ComponentClass));
            Tools.ThrowIfNull(ComponentClick, nameof(ComponentClick));
            Tools.ThrowIfNull(ComponentVisibilityFunc, nameof(ComponentVisibilityFunc));
        }


        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(DynamicTableActionMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentIcon), ComponentIcon);
            template.SetParameter(nameof(ComponentTitle), ComponentTitle);
            template.SetParameter(nameof(ComponentClass), ComponentClass);
            template.SetParameter(nameof(ComponentClick), ComponentClick);
            template.SetParameter(nameof(ComponentVisibilityFunc), ComponentVisibilityFunc);

            return template.Render();
        }


        


    }
}