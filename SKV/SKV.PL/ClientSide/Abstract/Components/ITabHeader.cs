using SKV.PL.ClientSide.Abstract.Features;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface ITabHeader : IComponent, ITitleable<ITabHeader>
    {
        ITabHeader Active(bool active);
        ITabHeader BodyId(string body_id);
    }
}
