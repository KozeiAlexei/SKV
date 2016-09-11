using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.PL.ClientSide.Abstract
{
    public interface IContent
    {
        IList<IComponent> Collection { get; }

        TComponent Create<TComponent>() where TComponent: class, IComponent, new();
    }
}
