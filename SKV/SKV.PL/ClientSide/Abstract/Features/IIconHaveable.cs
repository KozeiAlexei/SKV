namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IIconHaveable<TComponent, TIcon>
    {
        TComponent Icon(TIcon icon);
    }
}
