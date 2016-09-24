namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IFilterable<TComponent>
    {
        TComponent Filterable(bool filterable);
    }
}
