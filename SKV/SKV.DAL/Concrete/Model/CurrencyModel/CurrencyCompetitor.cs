using SKV.DAL.Abstract.Model.CurrencyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.CurrencyModel
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
