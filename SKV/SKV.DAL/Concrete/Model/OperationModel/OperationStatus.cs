using SKV.DAL.Abstract.Model.OperationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    public enum OperationType
    {
        Exchange,
        Correction,
        MoneyTransfer,
        Inventarisation
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
