namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IWidthable<TComponent>
    {
        uint ComponentWidth { get; set; }

        TComponent Width(uint width);
    }
}
