using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.ML.Concrete.Model.WindowModel;
using SKV.ML.Concrete.Model.CurrencyModel;
using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.ML.Concrete.Model.OperationModel
{
    public class InventarisationData : IInventarisationData<int, int, int, int, decimal>
    {
        [Key]
        public int Id { get; set; }

        public int InventarisationId { get; set; }

        [ForeignKey(nameof(InventarisationId))]
        public Inventarisation InventarisationInstance { get; set; }


        public decimal Result { get; set; }

        public decimal FactSum { get; set; }

        public decimal SystemSum { get; set; }


        public int CurrencyId { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency CurrencyInstance { get; set; }

    
        public int WindowId { get; set; }

        [ForeignKey(nameof(WindowId))]
        public Window WindowInstance { get; set; }

        public void CopyFrom(IInventarisationData<int, int, int, int, decimal> from)
        {
            Id = from.Id;
            InventarisationId = from.InventarisationId;

            Result = from.Result;
            FactSum = from.FactSum;
            SystemSum = from.SystemSum;

            WindowId = from.WindowId;
            CurrencyId = from.CurrencyId;
        }
    }
}
