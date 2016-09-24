using SKV.PL.ClientSide.Abstract.Features;

namespace SKV.PL.ClientSide.Abstract.Components
{
    public interface IModal : IComponent, 
                              IIdable<IModal>, ITitleable<IModal>, 
                              IBodyHaveable<IModal>
    {
        IModal ManualClosing(bool manual);
    }
}
