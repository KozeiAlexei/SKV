using SKV.PL.ClientSide.Abstract.Features;
using System;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface ITabBody : IComponent, IIdable<ITabBody>
    {
        ITabBody Body(Action<IContainer> body);
        ITabBody Active(bool active);
    }
}
