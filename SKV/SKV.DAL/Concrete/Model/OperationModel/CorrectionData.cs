using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.DAL.Abstract.Model.OperationModel;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    public class CorrectionData : ICorrectionData<int, int, int, int>
    {
        [Key]
        public int Id { get; set; }

        public int CorrectionId { get; set; }

        [ForeignKey(nameof(CorrectionId))]
        public Correction CorrectionInstance { get; set; }


        public decimal Sum { get; set; }

        public int WindowId { get; set; }

        public int CurrencyId { get; set; }


        public void CopyFrom(ICorrectionData<int, int, int, int> from)
        {
            Id = from.Id;
            CorrectionId = from.CorrectionId;

            Sum = from.Sum;
            WindowId = from.WindowId;
            CurrencyId = from.CurrencyId;
        }
    }
}
