using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Abstract.Components.Features;
using Ninject;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace SKV.PL.ClientSide.Components.Tabs
{
    public class TabsMvc : ITabs
    {
        #region Constructor

        public TabsMvc()
        {
            Model = new TabsMvcModel();
            Chain = Tools.CreateResponsibilityChain(this); 
        }

        private TabsMvcModel Model { get; set; }
        private IResponsibilityChain<TabsMvc> Chain { get; set; }

        #endregion


        #region Component setting

        public ITabs Id(string id) => Chain.Responsibility(() => Model.Id = id);

        public ITabs TabBody(Action<List<TabBodyMvcModel>> body) => Chain.Responsibility(() => body(Model.Body));
        public ITabs TabHeaders(Action<List<TabHeaderMvcModel>> headers) => Chain.Responsibility(() => headers(Model.Headers));

        #endregion


        public MvcHtmlString Render() => new ComponentRenderer(nameof(TabsMvc)).Render(Model);      
    }
} 