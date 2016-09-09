using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class ExchangeDataRepository : IExchangeDataRepository<ExchangeData, int, int, int?, int?>
    {
        public IRepository<ExchangeData, int> Repository { get; } =
            (IRepository<ExchangeData, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<ExchangeData, int>));
    }
}
