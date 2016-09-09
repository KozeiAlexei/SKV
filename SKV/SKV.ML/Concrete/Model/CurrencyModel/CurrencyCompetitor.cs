using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.ML.Concrete.Model.CurrencyModel
{
    public class CurrencyCompetitor : ICurrencyCompetitor<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Source { get; set; }

        public string ShortName { get; set; }

        public void CopyFrom(ICurrencyCompetitor<int> from)
        {
            Id = from.Id;
            Name = from.Name;
            Source = from.Source;
            ShortName = from.ShortName;
        }
    }
}
