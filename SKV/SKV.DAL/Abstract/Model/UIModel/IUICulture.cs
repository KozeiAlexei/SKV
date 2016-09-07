using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.UIModel
{
    public interface IUICulture<TKey> : IEntity<TKey>, ICloneableFrom<IUICulture<TKey>>
    {
        string Name { get; set; }

        string Culture { get; set; }
    }
}
