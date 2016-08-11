using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.CurrencyModel;

namespace SKV.DAL.Abstract.Repositories.CurrencyModel
{
    public interface ICurrencyRateDataRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ICurrencyRateData<TKey>
    {
        IEnumerable<string> GetMonitoringTickers();

        IEnumerable<TEntity> GetCurrencyRateDataList();

        TEntity GetCurrencyRateDataById(int id);

        TEntity GetCurrencyRateDataByTicker(string ticker);
    }
}
