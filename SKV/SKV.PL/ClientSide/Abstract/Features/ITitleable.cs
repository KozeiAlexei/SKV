namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface ITitleable<TComponent>
    {
        string ComponentTitle { get; set; }

        TComponent Title(string title);
    }
}
