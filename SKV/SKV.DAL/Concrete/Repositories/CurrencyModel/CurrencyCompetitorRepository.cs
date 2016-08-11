using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;

namespace SKV.DAL.Concrete.Repositories.CurrencyModel
{
    public class CurrencyCompetitorRepository : ICurrencyCompetitorRepository<CurrencyCompetitor, int>
    {
        public IRepository<CurrencyCompetitor, int> Repository { get; } =
            (IRepository<CurrencyCompetitor, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<CurrencyCompetitor, int>));
    }
}
