using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.WindowModel;
using SKV.DAL.Abstract.Repositories.WindowModel;

namespace SKV.DAL.Concrete.Repositories.WindowModel
{
    public class WindowCashRepository : IWindowCashRepository<WindowCash, int, int, int>
    {
        public IRepository<WindowCash, int> Repository { get; } =
            (IRepository<WindowCash, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<WindowCash, int>));

        public WindowCash GetWindowCashByWindowIdByCurrencyId(int window_id, int currency_id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.CurrencyId == currency_id && e.WindowId == window_id).FirstOrDefault());
    }
}
