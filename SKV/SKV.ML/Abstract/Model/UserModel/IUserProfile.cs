using System;

using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.UserModel
{
    public interface IUserProfile<TKey> : IEntity<TKey>, ICloneableFrom<IUserProfile<TKey>>
    {
        string Name { get; set; }


        DateTime LastLoginDate { get; set; }

        DateTime RegistrationDate { get; set; }
    }
}
