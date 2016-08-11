using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;

namespace SKV.DAL.Concrete.Repositories.CurrencyModel
{
    public class CurrencyExchangeRuleRepository : ICurrencyExchangeRuleRepository<CurrencyExchangeRule, int, int>
    {
        public IRepository<CurrencyExchangeRule, int> Repository { get; } =
            (IRepository<CurrencyExchangeRule, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<CurrencyExchangeRule, int>));

        public IEnumerable<CurrencyExchangeRule> GetExchangeableCurrencyByCurrencyId(int id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.CurrencyInId == id));
    }
}
