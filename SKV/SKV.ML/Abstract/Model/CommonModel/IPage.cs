using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.CommonModel
{
    public interface IPage<TKey> : IEntity<TKey>, ICloneableFrom<IPage<TKey>>
    { 
        string URL { get; set; }

        string Name { get; set; }
    }
}
