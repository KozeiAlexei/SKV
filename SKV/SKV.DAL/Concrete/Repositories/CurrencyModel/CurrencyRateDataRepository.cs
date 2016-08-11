using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;

namespace SKV.DAL.Concrete.Repositories.CurrencyModel
{
    public class CurrencyRateDataRepository : ICurrencyRateDataRepository<CurrencyRateData, int>
    {
        public IRepository<CurrencyRateData, int> Repository { get; } =
            (IRepository<CurrencyRateData, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<CurrencyRateData, int>));

        public CurrencyRateData GetCurrencyRateDataById(int id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Id == id).FirstOrDefault());

        public CurrencyRateData GetCurrencyRateDataByTicker(string ticker) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Ticker == ticker).FirstOrDefault());

        public IEnumerable<CurrencyRateData> GetCurrencyRateDataList() =>
            Repository.Sync.Synchronize(() => Repository.Table.AsEnumerable());

        public IEnumerable<string> GetMonitoringTickers() =>
            Repository.Sync.Synchronize(() => Repository.Table.Select(e => e.Ticker));
    }
}
