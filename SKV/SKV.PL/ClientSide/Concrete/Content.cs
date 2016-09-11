using System.Collections.Generic;

using SKV.PL.ClientSide.Abstract;

namespace SKV.PL.ClientSide.Concrete
{
    public class Content : IContent
    {
        public IList<IComponent> Collection { get; } = new List<IComponent>();

        public TComponent Create<TComponent>() where TComponent: class, IComponent, new()
        {
            var component = new TComponent(); Collection.Add(component);

            return component;
        }
    }
}