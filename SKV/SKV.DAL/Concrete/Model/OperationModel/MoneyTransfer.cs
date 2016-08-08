using SKV.DAL.Abstract.Model.OperationModel;
using SKV.DAL.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    public class MoneyTransfer : IMoneyTransfer<int, string, int>
    {
        [Key]
        public int Id { get; set; }

        public int DailyNumber { get; set; }


        public DateTime Date { get; set; }


        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public OperationStatus StatusInstance { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User UserInstance { get; set; }

        public List<MoneyTransferData> CorrectionData { get; set; } = new List<MoneyTransferData>();

        public void CopyFrom(IMoneyTransfer<int, string, int> from)
        {
            Id = from.Id;
            DailyNumber = from.DailyNumber;

            UserId = from.UserId;
            StatusId = from.StatusId;
        }
    }
}
