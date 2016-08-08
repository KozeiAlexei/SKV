using SKV.DAL.Abstract.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.CommonModel
{
    public class SystemSettings : ISystemSettings<int>
    {
        [Key]
        public int Id { get; set; }


        public int CanceledOrdersCountForBlackList { get; set; }

        public int CanceledOrderSumUSDForBlackList { get; set; }


        public int OrderDurationHours { get; set; }


        public string RBCLogin { get; set; }

        public string RBCPassword { get; set; }


        public int RBCMonitotingRateId { get; set; }

        public int RBCMonitoringFixedRateId { get; set; }


        public int RatesUpdatePeriod { get; set; }

        public int RBCMonitoringUpdatePeriod { get; set; }


        public void CopyFrom(ISystemSettings<int> from)
        {
            Id = from.Id;

            CanceledOrdersCountForBlackList = from.CanceledOrdersCountForBlackList;
            CanceledOrderSumUSDForBlackList = from.CanceledOrderSumUSDForBlackList;

            RatesUpdatePeriod = from.RatesUpdatePeriod;
            OrderDurationHours = from.OrderDurationHours;

            RBCLogin = from.RBCLogin;
            RBCPassword = from.RBCPassword;

            RBCMonitotingRateId = from.RBCMonitotingRateId;
            RBCMonitoringFixedRateId = from.RBCMonitoringFixedRateId;
            RBCMonitoringUpdatePeriod = from.RBCMonitoringUpdatePeriod;
        }
    }
}
