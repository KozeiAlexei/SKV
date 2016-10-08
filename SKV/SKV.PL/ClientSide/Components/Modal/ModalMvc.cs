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
            Model = new ModalMvcModel();
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private ModalMvcModel Model { get; set; }
        private IResponsibilityChain<ModalMvc> Chain { get; set; }

        #endregion

        #region Component setting

        public IModal Id(string id) => Chain.Responsibility(() => Model.Id = id);
        public IModal Body(Action<IContainer> body) => Chain.Responsibility(() => body(Model.Body));
        public IModal Title(string title) => Chain.Responsibility(() => Model.Title = title);
        public IModal ManualClosing(bool manual) => Chain.Responsibility(() => Model.ManualClosing = manual);

        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(ModalMvc)).Render(Model);
    }
}