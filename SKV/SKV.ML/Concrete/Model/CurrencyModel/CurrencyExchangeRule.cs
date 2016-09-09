using System;
using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.ML.Concrete.Model.CurrencyModel
{
    public class CurrencyExchangeRule : ICurrencyExchangeRule<int, int>
    {
        [Key]
        public int Id { get; set; }

        public int CurrencyInId { get; set; }

        public int CurrencyOutId { get; set; }

        public bool DisplayDirectRate { get; set; }

        public void CopyFrom(ICurrencyExchangeRule<int, int> from)
        {
            Id = from.Id;
            CurrencyInId = from.CurrencyInId;
            CurrencyOutId = from.CurrencyOutId;
        }
    }
}
