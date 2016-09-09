using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.UserModel
{
    public interface IUser<TKey> : IEntity<TKey>, ICloneableFrom<IUser<TKey>>
    {
    }
}
