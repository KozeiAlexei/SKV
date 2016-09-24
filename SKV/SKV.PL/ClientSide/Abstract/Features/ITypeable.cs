namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface ITypeable<TComponent, TType>
    {
        TComponent Type(TType type);
    }
}
