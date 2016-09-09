using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.UIModel
{
    public interface IUICulture<TKey> : IEntity<TKey>, ICloneableFrom<IUICulture<TKey>>
    {
        string Name { get; set; }

        string Culture { get; set; }
    }
}
