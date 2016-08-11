using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CommonModel
{
    public interface IPage<TKey> : IEntity<TKey>, ICloneableFrom<IPage<TKey>>
    { 
        string URL { get; set; }

        string Name { get; set; }
    }
}
