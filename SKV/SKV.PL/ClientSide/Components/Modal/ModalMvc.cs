using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;

namespace SKV.PL.ClientSide.Components.Modal
{
    public class ModalMvc : IModal
    {
        #region Constructor

        public ModalMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this);
            ComponentBody = Tools.CreateContainer();
        }

        private IResponsibilityChain<ModalMvc> Chain { get; set; }

        #endregion

        #region Component properties

        private string ComponentId { get; set; }
        private string ComponentTitle { get; set; }

        private IContainer ComponentBody { get; set; }

        private bool ComponentManualClosing { get; set; }

        #endregion

        #region Component setting

        public IModal Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public IModal Body(Action<IContainer> body) => Chain.Responsibility(() => body(ComponentBody));
        public IModal Title(string title) => Chain.Responsibility(() => ComponentTitle = title);
        public IModal ManualClosing(bool manual) => Chain.Responsibility(() => ComponentManualClosing = manual);

        #endregion

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentId, nameof(ComponentId));
            Tools.ThrowIfNull(ComponentTitle, nameof(ComponentTitle));
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(ModalMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentId), ComponentId);
            template.SetParameter(nameof(ComponentBody), () => ComponentBody.Render());
            template.SetParameter(nameof(ComponentTitle), ComponentTitle);
            template.SetParameter(nameof(ComponentManualClosing), () => ComponentManualClosing ? "data-backdrop=\"static\"" : string.Empty);

            return template.Render();
        }

    }
}