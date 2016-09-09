using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.UserModel
{
    public interface IUserPermission<TKey, TPermission> : IEntity<TKey>, ICloneableFrom<IUserPermission<TKey, TPermission>>
    {
        string Name { get; set; }

        TPermission Code { get; set; }
    }
}
