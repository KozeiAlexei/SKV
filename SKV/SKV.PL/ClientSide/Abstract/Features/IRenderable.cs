using System.Web.Mvc;

namespace SKV.PL.ClientSide.Abstract.Components.Features
{
    public interface IRenderable
    {
        MvcHtmlString Render();
    }
}
