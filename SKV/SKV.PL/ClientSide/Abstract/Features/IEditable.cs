namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IEditable<TComponent>
    {
        TComponent Editable(bool editable);
    }
}
