namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IPaginable<TComponent>
    {
        TComponent Paginable(bool paginable, uint? page_size = null);
    }
}
