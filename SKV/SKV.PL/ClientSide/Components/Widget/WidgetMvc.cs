using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

using Ninject;

using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using Ninject.Parameters;
using System;
using SKV.PL.ClientSide.Abstract.Components.Features;

namespace SKV.PL.ClientSide.Components.Widget
{
    public class WidgetMvc : IWidget
    {
        public WidgetMvc()
        {
            Chain = (IResponsibilityChain<WidgetMvc>)PLDependencyResolver.Kernel.Get(typeof(IResponsibilityChain<WidgetMvc>), 
                     new ConstructorArgument("obj", this));
        }

        private IResponsibilityChain<WidgetMvc> Chain { get; set; }

        #region Component properties

        public string ComponentId { get; set; }
        public string ComponentTitle { get; set; }

        public IContent ComponentBody { get; set; } = PLDependencyResolver.Kernel.Get<IContent>();
        #endregion

        #region Component setting

        public IWidget Id(string id) => Chain.Responsibility(() => ComponentId = id);
        public IWidget Title(string title) => Chain.Responsibility(() => ComponentTitle = title);

        public IWidget Body(Action<IContent> body) => Chain.Responsibility(() => body(ComponentBody));

        #endregion


        public MvcHtmlString Render()
        {
            var builder = new StringBuilder();

            builder.AppendLine();
            builder.AppendLine($"<widget id=\"{ ComponentId }\" title=\"{ ComponentTitle }\">");

            foreach (var part in ComponentBody.Collection)
                builder.AppendLine(part.Render().ToHtmlString());

            builder.AppendLine("</widget>");

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}