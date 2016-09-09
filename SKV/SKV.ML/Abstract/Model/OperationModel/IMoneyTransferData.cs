using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.OperationModel
{
    public interface IMoneyTransferData<TKey, TMoneyTransferKey, TWindowKey, TCurrencyKey, TMoneyTransferBase> 
        : IEntity<TKey>, ICloneableFrom<IMoneyTransferData<TKey, TMoneyTransferKey, TWindowKey, TCurrencyKey, TMoneyTransferBase>>
    {
        TMoneyTransferKey MoneyTransferId { get; set; }


        decimal SumIn { get; set; }

        TWindowKey WindowInId { get; set; }

        TCurrencyKey CurrencyInId { get; set; }


        decimal SumOut { get; set; }

        TWindowKey WindowOutId { get; set; }
     
        TCurrencyKey CurrencyOutId { get; set; }


        TMoneyTransferBase Base { get; set; }
    }
}
