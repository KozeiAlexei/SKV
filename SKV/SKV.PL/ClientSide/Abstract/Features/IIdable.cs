namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IIdable<TComponent>
    {
        string ComponentId { get; set; }

        TComponent Id(string id);
    }
}
