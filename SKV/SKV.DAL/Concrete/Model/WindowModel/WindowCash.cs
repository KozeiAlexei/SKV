using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.DAL.Abstract.Model.WindowModel;
using SKV.DAL.Concrete.Model.CurrencyModel;

namespace SKV.DAL.Concrete.Model.WindowModel
{
    public class WindowCash : IWindowCash<int, int, int>
    {
        [Key]
        public int Id { get; set; }

        public decimal Sum { get; set; }


        public int CurrencyId { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency CurrencyInstance { get; set; }


        public int WindowId { get; set; }

        [ForeignKey(nameof(WindowId))]
        public Window WindowInstance { get; set; }

        public void CopyFrom(IWindowCash<int, int, int> from)
        {
            Id = from.Id;
            Sum = from.Sum;

            WindowId = from.WindowId;
            CurrencyId = from.CurrencyId;
        }
    }
}
