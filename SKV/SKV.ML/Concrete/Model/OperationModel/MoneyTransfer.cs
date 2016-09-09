﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.ML.Concrete.Model.OperationModel
{
    public class MoneyTransfer : IMoneyTransfer<int, string, int>
    {
        [Key]
        public int Id { get; set; }

        public int DailyNumber { get; set; }

        [Column(TypeName = "datetime2")]
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