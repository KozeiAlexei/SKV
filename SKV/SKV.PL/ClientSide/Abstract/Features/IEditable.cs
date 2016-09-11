namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IEditable<TComponent>
    {
        bool ComponentEditable { get; set; }

        TComponent Editable(bool editable);
    }
}
