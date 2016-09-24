using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Abstract.Components.Features;
using Ninject;
using System.Text;
using System.Linq;

namespace SKV.PL.ClientSide.Components.Tabs
{
    public class TabsMvc : ITabs
    {
        #region Constructor

        public TabsMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this); 
        }

        private IResponsibilityChain<TabsMvc> Chain { get; set; }

        #endregion

        #region Component properties

        internal string ComponentId { get; set; }

        internal IContainer ComponentTabBody { get; set; } = Tools.CreateContainer();
        internal IContainer ComponentTabHeaders { get; set; } = Tools.CreateContainer();

        #endregion

        #region Component setting

        public ITabs Id(string id) => Chain.Responsibility(() => ComponentId = id);

        public ITabs TabBody(Action<IContainer> body) => Chain.Responsibility(() => body(ComponentTabBody));
        public ITabs TabHeaders(Action<IContainer> headers) => Chain.Responsibility(() => headers(ComponentTabHeaders));

        #endregion

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentId, nameof(ComponentId));

            var active_body = ComponentTabBody.GetContainerObjects().Cast<TabBodyMvc>().Where(o => o.ComponentActive);
            var active_header = ComponentTabHeaders.GetContainerObjects().Cast<TabHeaderMvc>().Where(o => o.ComponentActive);

            Tools.ThrowIfCondition($"{ nameof(ComponentTabHeaders) } and { nameof(ComponentTabBody) }", 
                () => active_header.Single().ComponentBodyId != active_body.Single().ComponentId);
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(TabsMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentId), ComponentId);
            template.SetParameter(nameof(ComponentTabBody), ComponentTabBody.Render());
            template.SetParameter(nameof(ComponentTabHeaders), ComponentTabHeaders.Render());

            return template.Render();
        }
    }
} 