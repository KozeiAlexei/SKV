using Ninject;
using Ninject.Modules;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using SKV.PL.ClientSide.Components;
using SKV.PL.ClientSide.Components.DynamicTable;
using SKV.PL.ClientSide.Components.Modal;
using SKV.PL.ClientSide.Components.Tabs;
using SKV.PL.ClientSide.Components.Widget;
using SKV.PL.ClientSide.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKV.PL
{
    public class PLDependencyResolver
    {
        private class NInjectBindings : NinjectModule
        {
            public override void Load()
            {
                Bind(typeof(IResponsibilityChain<ModalMvc>)).To(typeof(ResponsibilityChain<ModalMvc>));
                Bind(typeof(IResponsibilityChain<WidgetMvc>)).To(typeof(ResponsibilityChain<WidgetMvc>));
                Bind(typeof(IResponsibilityChain<ContentMvc>)).To(typeof(ResponsibilityChain<ContentMvc>));

                Bind(typeof(IResponsibilityChain<DynamicTableMvc>)).To(typeof(ResponsibilityChain<DynamicTableMvc>));
                Bind(typeof(IResponsibilityChain<DynamicTableActionMvc>)).To(typeof(ResponsibilityChain<DynamicTableActionMvc>));
                Bind(typeof(IResponsibilityChain<DynamicTableColumnMvc>)).To(typeof(ResponsibilityChain<DynamicTableColumnMvc>));

                Bind(typeof(IResponsibilityChain<TabsMvc>)).To(typeof(ResponsibilityChain<TabsMvc>));

                Bind<IContainer>().To<Container>();
            }
        }

        public static IKernel Kernel { get; } = new StandardKernel(new NInjectBindings());
    }
}