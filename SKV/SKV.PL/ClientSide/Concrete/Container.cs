using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

using SKV.PL.ClientSide.Abstract;
using System;

namespace SKV.PL.ClientSide.Concrete
{
    public class Container : IContainer
    {
        private IList<IComponent> Collection { get; } = new List<IComponent>();

        public TComponent Create<TComponent>() where TComponent: class, IComponent, new()
        {
            var component = new TComponent(); Collection.Add(component);

            return component;
        }

        public IEnumerable<IComponent> GetContainerObjects() => Collection;

        public string Render()
        {
            var builder = new StringBuilder();

            foreach (var item in Collection)
                builder.AppendLine(item.Render().ToHtmlString());

            return builder.ToString();
        }
    }
}