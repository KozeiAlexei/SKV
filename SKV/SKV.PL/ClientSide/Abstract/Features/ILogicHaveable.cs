using System;

namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface ILogicHaveable<TComponent>
    {
        TComponent Logic(Action<IContainer> logic);
    }
}
