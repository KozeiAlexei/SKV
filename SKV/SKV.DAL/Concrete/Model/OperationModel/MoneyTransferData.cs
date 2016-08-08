using SKV.DAL.Abstract.Model.OperationModel;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Concrete.Model.WindowModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    public enum MoneyTransferBase
    {
        Encashment,
        PutToWindow,
        PutToExternalSource,
        GetFromExternalSource
    }

    public class MoneyTransferData : IMoneyTransferData<int, int, int?, int?, MoneyTransferBase>
    {
        [Key]
        public int Id { get; set; }

        public int MoneyTransferId { get; set; }

        [ForeignKey(nameof(MoneyTransferId))]
        public MoneyTransfer MoneyTransferInstance { get; set; }


        public MoneyTransferBase Base { get; set; }


        public decimal SumIn { get; set; }

        public decimal SumOut { get; set; }


        public int? CurrencyInId { get; set; }

        [ForeignKey(nameof(CurrencyInId))]
        public Currency CurrencyInInstance { get; set; }

        public int? CurrencyOutId { get; set; }

        [ForeignKey(nameof(CurrencyOutId))]
        public Currency CurrencyOutInstance { get; set; }
 

        public int? WindowInId { get; set; }

        [ForeignKey(nameof(WindowInId))]
        public Window WindowInInstance { get; set; }

        public int? WindowOutId { get; set; }

        [ForeignKey(nameof(WindowOutId))]
        public Window WindowOutInstance { get; set; }


        public void CopyFrom(IMoneyTransferData<int, int, int?, int?, MoneyTransferBase> from)
        {
            Id = from.Id;
            Base = from.Base;
            MoneyTransferId = from.MoneyTransferId;

            SumIn = from.SumIn;
            SumOut = from.SumOut;

            CurrencyInId = from.CurrencyInId;
            CurrencyOutId = from.CurrencyOutId;

            WindowInId = from.WindowInId;
            WindowOutId = from.WindowOutId;
        }
    }
}
