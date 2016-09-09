using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.CommonModel
{
    public interface ISystemSettings<TKey, TUICultureKey> : IEntity<TKey>, ICloneableFrom<ISystemSettings<TKey, TUICultureKey>>
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

        TUICultureKey DefaultCultureId { get; set; }
    }
}
