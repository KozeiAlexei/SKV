using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.Widget
{
    public class WidgetMvc : IWidget
    {
        #region Constructor

        public WidgetMvc()
        {
            Model = new WidgetMvcModel();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private WidgetMvcModel Model { get; set; }
        private IResponsibilityChain<WidgetMvc> Chain { get; set; }

        #endregion

        #region Component setting

        public IWidget Id(string id) => Chain.Responsibility(() => Model.Id = id);
        public IWidget Title(string title) => Chain.Responsibility(() => Model.Title = title);

        public IWidget Body(Action<IContainer> body) => Chain.Responsibility(() => body(Model.Body));

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(WidgetMvc)).Render(Model);
    }
}