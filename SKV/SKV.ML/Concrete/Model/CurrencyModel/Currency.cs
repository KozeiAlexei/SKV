using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.ML.Concrete.Model.CurrencyModel
{
    public class Currency : ICurrency<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public void CopyFrom(ICurrency<int> from)
        {
            Id = from.Id;
            Name = from.Name;
            ShortName = from.ShortName;
        }
    }
}
