using SKV.DAL.Abstract.Model.CurrencyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.CurrencyModel
{
    public class CurrencyRateData : ICurrencyRateData<int>
    {
        [Key]
        public int Id { get; set; }


        public int Code { get; set; }

        public int Ammount { get; set; }

        
        public string Ticker { get; set; }


        public void CopyFrom(ICurrencyRateData<int> from)
        {
            Id = from.Id;
            Code = from.Code;
            Ammount = from.Ammount;

            Ticker = from.Ticker;
        }
    }
}
