using System;
using System.Web.Mvc;
using System.Collections.Generic;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract.Components;

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

        public ITabs Tabs(Action<List<TabMvcModel>> body) => Chain.Responsibility(() => body(Model.Tabs));
        #endregion

        public MvcHtmlString Render() => new ComponentRenderer(nameof(TabsMvc)).Render(Model);      
    }
} 