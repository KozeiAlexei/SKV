namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface ITypeable<TComponent, TType>
    {
        TType ComponentType { get; set; }

        TComponent Type(TType type);
    }
}
