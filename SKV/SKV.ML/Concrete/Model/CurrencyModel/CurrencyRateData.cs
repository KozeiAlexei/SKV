using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.ML.Concrete.Model.CurrencyModel
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
