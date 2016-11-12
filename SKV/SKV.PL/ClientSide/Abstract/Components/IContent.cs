using System.Web.Mvc;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IContent : IComponent
    {
        IContent FromPartitalView(MvcHtmlString logic);

        IContent FromPartitalView<TModel>(string partitalPath, TModel model) where TModel : class;
    }
}
