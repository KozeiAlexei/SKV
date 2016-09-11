using SKV.PL.ClientSide.Abstract.Components.Features;
using SKV.PL.ClientSide.Abstract.Features;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IWidget : IComponent, IIdable<IWidget>, ITitleable<IWidget>, IBodyHaveable<IWidget>
    {
    }
}
