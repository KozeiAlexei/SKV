using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.UserModel
{
    public interface IUserPermission<TKey, TPermission> : IEntity<TKey>, ICloneableFrom<IUserPermission<TKey, TPermission>>
    {
        string Name { get; set; }

        TPermission Code { get; set; }
    }
}
