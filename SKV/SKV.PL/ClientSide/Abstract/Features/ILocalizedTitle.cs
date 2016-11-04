namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface ILocalizedTitle<TComponent>
    {
        TComponent TitleKey(string key);
    }
}
