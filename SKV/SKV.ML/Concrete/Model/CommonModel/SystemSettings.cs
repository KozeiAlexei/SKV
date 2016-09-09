using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.CommonModel;
using SKV.ML.Concrete.Model.UIModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKV.ML.Concrete.Model.CommonModel
{
    public class SystemSettings : ISystemSettings<int, int>
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


        public int DefaultCultureId { get; set; }

        [ForeignKey(nameof(DefaultCultureId))]
        public UICulture DefaultUICultureInstance { get; set; }

        public void CopyFrom(ISystemSettings<int, int> from)
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
