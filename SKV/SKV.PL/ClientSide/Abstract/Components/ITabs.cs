using System;

using SKV.PL.ClientSide.Abstract.Features;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface ITabs : IComponent, IIdable<ITabs>
    {
        ITabs TabBody(Action<IContainer> body);
        ITabs TabHeaders(Action<IContainer> headers);
    }
}
