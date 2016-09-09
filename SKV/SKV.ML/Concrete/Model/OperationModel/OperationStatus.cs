using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.ML.Concrete.Model.OperationModel
{
    public enum OperationType
    {
        Exchange,
        Correction,
        MoneyTransfer,
        Inventarisation
    }

    public enum ExchangeStatus
    {
        Claim,
        Order,
        Finalized,
        CanceledByClientReason,
        CanceledByOperatorError,
        CanceledWithAddingToBlackList,
        CanceledByDayExpired
    }

    public class OperationStatus : IOperationStatus<int, OperationType, int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }


        public int StatusCode { get; set; }

        public OperationType OperationType { get; set; }


        public void CopyFrom(IOperationStatus<int, OperationType, int> from)
        {
            Id = from.Id;
            Name = from.Name;
            Text = from.Text;
            Description = from.Description;

            StatusCode = from.StatusCode;
            OperationType = from.OperationType;
        }
    }
}
