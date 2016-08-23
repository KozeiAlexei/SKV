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

        public CurrencyExchangeRule GetCurrencyExchangeRule(int curr_in_id, int curr_out_id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.CurrencyInId == curr_in_id && e.CurrencyOutId == curr_out_id).FirstOrDefault());

        public IEnumerable<CurrencyExchangeRule> GetCurrencyExchangeRulesByCurrencyId(int id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.CurrencyInId == id));
    }
}
