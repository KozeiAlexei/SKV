using System.Web.Mvc;

using SKV.PL.ClientSide.Concrete;
using SKV.PL.ClientSide.Abstract;
using SKV.PL.ClientSide.Abstract.Components;
using System.Web;

namespace SKV.PL.ClientSide.Components
{
    public class ContentMvc : IContent
    {
        public ContentMvc()
        {
            Chain = Tools.CreateResponsibilityChain(this);
        }

        private IResponsibilityChain<ContentMvc> Chain { get; set; }

        #region Component properties

        internal MvcHtmlString ComponentLogic { get; set; }

        #endregion

        #region Component setting

        public IContent FromPartitalView(MvcHtmlString logic) => Chain.Responsibility(() => ComponentLogic = logic);

        public IContent FromPartitalView<TModel>(string partitalName, TModel model = null) where TModel : class =>
            FromPartitalView(MvcHtmlString.Create(ViewRenderer.RenderPartialView(partitalName, model, null)));

        public IContent FromPartitalView<TModel>(string partitalName, ControllerContext controllerContext, TModel model = null) where TModel : class =>
            FromPartitalView(MvcHtmlString.Create(ViewRenderer.RenderPartialView(partitalName, model, controllerContext)));

        #endregion

        public MvcHtmlString Render() => ComponentLogic;
    }
}