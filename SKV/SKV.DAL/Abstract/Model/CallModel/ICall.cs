using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CallModel
{
    public interface ICall<TKey, TCallType> : IEntity<TKey>, ICloneableFrom<ICall<TKey, TCallType>>
    {
        TCallType Type { get; set; }

        string CallerPhoneNumber { get; set; }

        string AcceptorPhoneNumber { get; set; }

        int? AcceptorPhoneNumberId { get; set; }
        
        int? OperatorId { get; set; }
     
        string AsteriskUniqueId { get; set; }

        DateTime CallStartDate { get; set; }

        DateTime? CallConnectedDate { get; set; }

        DateTime? CallEndDate { get; set; }
    }
}
