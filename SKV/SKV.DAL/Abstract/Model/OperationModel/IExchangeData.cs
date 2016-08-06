using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IExchangeData<TKey, TExchangeKey, TCurrencyKey, TBankOperationKey> :
        IEntity<TKey>, ICloneableFrom<IExchangeData<TKey, TExchangeKey, TCurrencyKey, TBankOperationKey>>
    {
        TExchangeKey ExchangeId { get; set; }

        TCurrencyKey BankCurrencyId { get; set; }

        TCurrencyKey ClientCurrencyId { get; set; }

        TBankOperationKey BankOperationId { get; set; }


        decimal TotalSum { get; set; }

        decimal ClientSum { get; set; }


        decimal TotalRate { get; set; }

        decimal ForexRate { get; set; }

        decimal ExchangerRate { get; set; }
    }
}
