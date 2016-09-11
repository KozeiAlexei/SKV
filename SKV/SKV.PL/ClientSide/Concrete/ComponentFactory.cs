using SKV.PL.ClientSide.Abstract;

namespace SKV.PL.ClientSide.Concrete
{
    public static class ComponentFactory
    {
        public static TComponent Create<TComponent>() where TComponent : class, IComponent, new() => new TComponent();
    }
}