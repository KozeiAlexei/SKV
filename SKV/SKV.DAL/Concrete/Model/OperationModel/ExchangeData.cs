using SKV.DAL.Abstract.Model.OperationModel;
using System;
using SKV.DAL.Concrete.Model.CurrencyModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    public class ExchangeData : IExchangeData<int, int, int, int?>
    {
        [Key]
        public int Id { get; set; }

        public int ExchangeId { get; set; }

        [ForeignKey(nameof(ExchangeId))]
        public Exchange ExchangeInstance { get; set; }


        public decimal TotalSum { get; set; }

        public decimal ClientSum { get; set; }


        public int? BankOperationId { get; set; }


        public decimal ForexRate { get; set; }

        public decimal TotalRate { get; set; }

        public decimal ExchangerRate { get; set; }

        
        public int BankCurrencyId { get; set; }

        [ForeignKey(nameof(BankCurrencyId))]
        public Currency BankCurrencyInstance { get; set; }


        public int ClientCurrencyId { get; set; }

        [ForeignKey(nameof(ClientCurrencyId))]
        public Currency ClientCurrencyInstance { get; set; }


        public void CopyFrom(IExchangeData<int, int, int, int?> from)
        {
            Id = from.Id;
            ExchangeId = from.Id;

            TotalSum = from.TotalSum;
            ClientSum = from.ClientSum;

            BankOperationId = from.BankOperationId;

            ForexRate = from.ForexRate;
            TotalRate = from.TotalRate;
            ExchangerRate = from.ExchangerRate;

            BankCurrencyId = from.BankCurrencyId;
            ClientCurrencyId = from.ClientCurrencyId;
        }
    }
}
