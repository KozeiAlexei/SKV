using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.ML.Abstract.Model.OperationModel;
using SKV.ML.Concrete.Model.CurrencyModel;

namespace SKV.ML.Concrete.Model.OperationModel
{
    public class ExchangeData : IExchangeData<int, int, int?, int?>
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

        
        public int? BankCurrencyId { get; set; }

        [ForeignKey(nameof(BankCurrencyId))]
        public Currency BankCurrencyInstance { get; set; }


        public int? ClientCurrencyId { get; set; }

        [ForeignKey(nameof(ClientCurrencyId))]
        public Currency ClientCurrencyInstance { get; set; }


        public void CopyFrom(IExchangeData<int, int, int?, int?> from)
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
