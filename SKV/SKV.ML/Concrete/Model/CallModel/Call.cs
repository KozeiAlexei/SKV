using System;
using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CallModel;

namespace SKV.ML.Concrete.Model.CallModel
{
    /// <summary>
    /// Тип звонка
    /// </summary>
    public enum CallType
    {
        /// <summary>
        /// Входящий звонок
        /// </summary>
        Incoming,

        /// <summary>
        /// Исходящий звонок
        /// </summary>
        Outgoing
    }

    public class Call : ICall<int, CallType>
    {
        [Key]
        public int Id { get; set; }


        public int? OperatorId { get; set; }

        public int? AcceptorPhoneNumberId { get; set; }

        public string AcceptorPhoneNumber { get; set; }

        public string AsteriskUniqueId { get; set; }


        public DateTime? CallConnectedDate { get; set; }

        public DateTime? CallEndDate { get; set; }

        public string CallerPhoneNumber { get; set; }

        public DateTime CallStartDate { get; set; }

        public CallType Type { get; set; }


        public void CopyFrom(ICall<int, CallType> from)
        {
            Id = from.Id;
            OperatorId = from.OperatorId;

            Type = from.Type;
            AsteriskUniqueId = from.AsteriskUniqueId;

            CallEndDate = from.CallEndDate;
            CallStartDate = from.CallStartDate;
            CallConnectedDate = from.CallConnectedDate;

            CallerPhoneNumber = from.CallerPhoneNumber;

            AcceptorPhoneNumber = from.AcceptorPhoneNumber;
            AcceptorPhoneNumberId = from.AcceptorPhoneNumberId;
        }
    }
}
