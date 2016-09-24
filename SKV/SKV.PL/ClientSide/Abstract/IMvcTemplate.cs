using System;
using System.Web.Mvc;

using SKV.PL.ClientSide.Abstract.Components.Features;

namespace SKV.PL.ClientSide.Abstract
{
    public interface IMvcTemplate : IRenderable<MvcHtmlString>
    {
        void SetParameter(string param_name, string param_value);
        void SetParameter(string param_name, Func<string> param_value_func);
    }
}
