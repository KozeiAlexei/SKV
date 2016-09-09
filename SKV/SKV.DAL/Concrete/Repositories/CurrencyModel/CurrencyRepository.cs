using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.CurrencyModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;

namespace SKV.DAL.Concrete.Repositories.CurrencyModel
{
    public class CurrencyRepository : ICurrencyRepository<Currency, int>
    {
        public IRepository<Currency, int> Repository { get; } =
            (IRepository<Currency, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Currency, int>));

        public Currency GetCurrencyByShortName(string short_name) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.ShortName == short_name).FirstOrDefault());

        public IEnumerable<string> GetCurrencyShortNames() =>
            Repository.Sync.Synchronize(() => Repository.Table.Select(e => e.ShortName));
    }
}
