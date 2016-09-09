using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Abstract.Repositories.CurrencyModel
{
    public interface ICurrencyExchangeRuleRepository<TEntity, TKey, TCurrencyKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICurrencyExchangeRule<TKey, TCurrencyKey>
    {
        IEnumerable<TEntity> GetCurrencyExchangeRulesByCurrencyId(TCurrencyKey id);

        TEntity GetCurrencyExchangeRule(TCurrencyKey curr_in_id, TCurrencyKey curr_out_id);
    }
}
