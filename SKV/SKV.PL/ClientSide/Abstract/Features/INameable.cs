namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface INameable<TComponent>
    {
        string ComponentName { get; set; }

        TComponent Name(string name);
    }
}
