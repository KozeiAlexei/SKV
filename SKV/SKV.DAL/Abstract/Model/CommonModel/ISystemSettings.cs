using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CommonModel
{
    public interface ISystemSettings<TKey> : IEntity<TKey>, ICloneableFrom<ISystemSettings<TKey>>
    {
        string RBCLogin { get; set; }

        string RBCPassword { get; set; }

        int OrderDurationHours { get; set; }

        int CanceledOrdersCountForBlackList { get; set; }

        int CanceledOrderSumUSDForBlackList { get; set; }

        int RatesUpdatePeriod { get; set; }

        int RBCMonitotingRateId { get; set; }

        int RBCMonitoringFixedRateId { get; set; }

        int RBCMonitoringUpdatePeriod { get; set; }
    }
}
