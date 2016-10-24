namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IImportFromModel<TComponent, TModel>
    {
        TComponent ImportFromModel(TModel model);
    }
}
