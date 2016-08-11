using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;

namespace SKV.DAL.Concrete.Repositories.CurrencyModel
{
    public class CurrencyRateRepository : ICurrencyRateRepository<CurrencyRate, int>
    {
        public IRepository<CurrencyRate, int> Repository { get; } =
            (IRepository<CurrencyRate, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<CurrencyRate, int>));

        public CurrencyRate GetCurrencyRateByTickerBySum(string ticker, decimal sum) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Ticker == ticker && e.Sum == sum).FirstOrDefault());
    }
}
