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
            Chain = Tools.CreateResponsibilityChain(this);
            ComponentBody = Tools.CreateContainer();
        }

        private IResponsibilityChain<WidgetMvc> Chain { get; set; }

        #endregion

        #region Component properties

        private string ComponentId { get; set; }
        private string ComponentTitle { get; set; }

        private IContainer ComponentBody { get; set; }
        #endregion

        #region Component setting

        public IWidget Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public IWidget Title(string title) => Chain.Responsibility(() => ComponentTitle = title);

        public IWidget Body(Action<IContainer> body) => Chain.Responsibility(() => body(ComponentBody));

        #endregion

        public void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentId, nameof(ComponentId));
            Tools.ThrowIfNull(ComponentTitle, nameof(ComponentTitle));
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(WidgetMvc));

            template.SetParameter(nameof(ComponentId), ComponentId);
            template.SetParameter(nameof(ComponentBody), () => ComponentBody.Render());
            template.SetParameter(nameof(ComponentTitle), ComponentTitle);

            return template.Render();
        }
    }
}