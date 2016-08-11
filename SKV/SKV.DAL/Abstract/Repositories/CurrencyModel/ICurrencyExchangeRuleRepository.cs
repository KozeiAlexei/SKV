using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Abstract.Repositories.CurrencyModel
{
    public interface ICurrencyExchangeRuleRepository<TEntity, TKey, TCurrencyKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICurrencyExchangeRule<TKey, TCurrencyKey>
    {
        IEnumerable<TEntity> GetExchangeableCurrencyByCurrencyId(int id);
    }
}
