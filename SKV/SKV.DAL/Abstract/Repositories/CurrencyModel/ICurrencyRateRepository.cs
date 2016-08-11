using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Abstract.Repositories.CurrencyModel
{
    public interface ICurrencyRateRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICurrencyRate<TKey>
    {
        TEntity GetCurrencyRateByTickerBySum(string ticker, decimal sum);
    }
}
