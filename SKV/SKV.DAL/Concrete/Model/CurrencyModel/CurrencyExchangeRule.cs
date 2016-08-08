using SKV.DAL.Abstract.Model.CurrencyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.CurrencyModel
{
    public class CurrencyExchangeRule : ICurrencyExchangeRule<int, int>
    {
        [Key]
        public int Id { get; set; }

        public int CurrencyInId { get; set; }

        public int CurrencyOutId { get; set; }


        public void CopyFrom(ICurrencyExchangeRule<int, int> from)
        {
            Id = from.Id;
            CurrencyInId = from.CurrencyInId;
            CurrencyOutId = from.CurrencyOutId;
        }
    }
}
