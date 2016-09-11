namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IFilterable<TComponent>
    {
        bool ComponentFilterable { get; set; }

        TComponent Filterable(bool filterable);
    }
}
