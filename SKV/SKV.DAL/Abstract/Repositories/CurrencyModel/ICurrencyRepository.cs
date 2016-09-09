using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Abstract.Repositories.CurrencyModel
{
    public interface ICurrencyRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICurrency<TKey>
    {
        IEnumerable<string> GetCurrencyShortNames();

        TEntity GetCurrencyByShortName(string short_name);
    }
}
