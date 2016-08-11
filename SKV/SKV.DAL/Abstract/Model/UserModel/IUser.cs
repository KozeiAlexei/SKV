using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.UserModel
{
    public interface IUser<TKey> : IEntity<TKey>, ICloneableFrom<IUser<TKey>>
    {
    }
}
