using SKV.DAL.Abstract.Model.OperationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SKV.DAL.Concrete.Model.UserModel;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    public class Inventarisation : IInventarisation<int, string, int>
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

        public List<InventarisationData> CorrectionData { get; set; } = new List<InventarisationData>();

        public void CopyFrom(IInventarisation<int, string, int> from)
        {
            Id = from.Id;
            DailyNumber = from.DailyNumber;

            UserId = from.UserId;
            StatusId = from.StatusId;
        }
    }
}
