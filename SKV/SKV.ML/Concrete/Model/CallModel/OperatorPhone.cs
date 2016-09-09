using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CallModel;

namespace SKV.ML.Concrete.Model.CallModel
{
    public class OperatorPhone : IOperatorPhone<int>
    {
        [Key]
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public void CopyFrom(IOperatorPhone<int> from)
        {
            Id = from.Id;
            PhoneNumber = from.PhoneNumber;
        }
    }
}
