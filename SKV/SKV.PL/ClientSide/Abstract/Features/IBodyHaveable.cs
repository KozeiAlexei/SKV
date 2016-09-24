using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IBodyHaveable<TComponent>
    {
        TComponent Body(Action<IContainer> body);
    }
}
