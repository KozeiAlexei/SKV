using System;

using SKV.PL.ClientSide.Abstract.Features;
using System.Collections.Generic;
using SKV.PL.ClientSide.Components.Tabs;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface ITabs : IComponent, IIdable<ITabs>
    {
        ITabs TabBody(Action<List<TabBodyMvcModel>> body);
        ITabs TabHeaders(Action<List<TabHeaderMvcModel>> headers);
    }
}
