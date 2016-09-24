using SKV.PL.ClientSide.Abstract.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SKV.PL.ClientSide.Abstract;
using System.Web.Mvc;
using SKV.PL.ClientSide.Concrete;
using Ninject;

namespace SKV.PL.ClientSide.Components.Tabs
{
    public class TabBodyMvc : ITabBody
    {
        #region Constructor

        public TabBodyMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this);
            ComponentTabBody = Tools.CreateContainer();
        }

        private IResponsibilityChain<TabBodyMvc> Chain { get; set; }

        #endregion

        #region Component properties

        internal string ComponentId { get; set; }
        internal bool ComponentActive { get; set; }
        internal IContainer ComponentTabBody { get; set; }

        #endregion

        #region Component setting

        public ITabBody Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public ITabBody Body(Action<IContainer> body) => Chain.Responsibility(() => body(ComponentTabBody));
        public ITabBody Active(bool active) => Chain.Responsibility(() => ComponentActive = active);

        #endregion

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentId, nameof(ComponentId)); 
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(TabBodyMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentId), ComponentId);
            template.SetParameter(nameof(ComponentTabBody), ComponentTabBody.Render());
            template.SetParameter(nameof(ComponentActive), () => ComponentActive ? "active in" : string.Empty);

            return template.Render();
        }
    }
}