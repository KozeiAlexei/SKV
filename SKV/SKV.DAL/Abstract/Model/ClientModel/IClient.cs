using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.ClientModel
{
    public interface IClient<TKey, TStatusKey, TClientCode> : IEntity<TKey>, ICloneableFrom<IClient<TKey, TStatusKey, TClientCode>>
    {
        string Name { get; set; }

        string Phone { get; set; }

        DateTime RegistrationDate { get; set; }


        TClientCode Code { get; set; }


        TStatusKey StatusId { get; set; }
    }
}
