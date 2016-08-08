using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.UserModel
{
    public interface IUserProfile<TKey> : IEntity<TKey>, ICloneableFrom<IUserProfile<TKey>>
    {
        string Name { get; set; }


        DateTime LastLoginDate { get; set; }

        DateTime RegistrationDate { get; set; }
    }
}
