using System;
using System.ComponentModel.DataAnnotations;

using SKV.DAL.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Concrete.Model.CurrencyModel
{
    public class CurrencyRate : ICurrencyRate<int>
    {
        [Key]
        public int Id { get; set; }

        public bool Commission { get; set; }

        public DateTime LastUpdate { get; set; }


        public decimal Sum { get; set; }

        public decimal Sale { get; set; }

        public decimal Purchase { get; set; }

        
        public string Ticker { get; set; }


        public void CopyFrom(ICurrencyRate<int> from)
        {
            Id = from.Id;
            Commission = from.Commission;
            LastUpdate = from.LastUpdate;

            Sum = from.Sum;
            Sale = from.Sale;
            Purchase = from.Purchase;

            Ticker = from.Ticker;
        }
    }
}
