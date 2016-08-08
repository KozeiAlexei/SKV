using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.UserModel
{
    public interface IUserRole<TKey, TDefaultRole> : IEntity<TKey>, ICloneableFrom<IUserRole<TKey, TDefaultRole>>
    {
        string Name { get; set; }

        int DefaultPageId { get; set; }


        TDefaultRole DefaultRoleCode { get; set; }
    }
}
