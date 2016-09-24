using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL.ClientSide.Components.Tabs
{
    public class TabHeaderMvc : ITabHeader
    {
        #region Constructor

        public TabHeaderMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private IResponsibilityChain<TabHeaderMvc> Chain { get; set; }

        #endregion

        #region Component properties

        internal bool ComponentActive { get; set; }

        internal string ComponentTitle { get; set; }
        internal string ComponentBodyId { get; set; }

        #endregion

        #region Component setting

        public ITabHeader Title(string title) => Chain.Responsibility(() => ComponentTitle = title);
        public ITabHeader BodyId(string id) => Chain.Responsibility(() => ComponentBodyId = id);
        public ITabHeader Active(bool active) => Chain.Responsibility(() => ComponentActive = active);

        #endregion

        private void PrerenderValidation()
        {
            Tools.ThrowIfNull(ComponentTitle, nameof(ComponentTitle));
            Tools.ThrowIfNull(ComponentBodyId, nameof(ComponentBodyId));
        }

        public MvcHtmlString Render()
        {
            var template = Tools.CreateMvcTemplate(nameof(TabHeaderMvc)); PrerenderValidation();

            template.SetParameter(nameof(ComponentTitle), ComponentTitle);
            template.SetParameter(nameof(ComponentBodyId), ComponentBodyId);
            template.SetParameter(nameof(ComponentActive), () => ComponentActive ? "class=\"active\"" : "class=\"\"");

            return template.Render();
        }
    }
}