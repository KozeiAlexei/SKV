using System;
using System.Collections.Generic;

using SKV.PL.ClientSide.Abstract.Features;
using SKV.PL.ClientSide.Components.Tabs;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface ITabs : IComponent, IIdable<ITabs>
    {
        ITabs Tabs(Action<List<TabMvcModel>> body);
    }
}
