using System.Collections.Generic;

using SKV.PL.ClientSide.Abstract.Components.Features;

namespace SKV.PL.ClientSide.Abstract
{
    public interface IContainer : IRenderable<string>
    {
        TComponent Create<TComponent>() where TComponent: class, IComponent, new();

        IEnumerable<IComponent> GetContainerObjects();
    }
}
