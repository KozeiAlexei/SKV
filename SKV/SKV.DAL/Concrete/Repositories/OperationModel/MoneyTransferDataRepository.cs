using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class MoneyTransferDataRepository : IMoneyTransferDataRepository<MoneyTransferData, int, int, int?, int?, MoneyTransferBase>
    {
        public IRepository<MoneyTransferData, int> Repository { get; } =
            (IRepository<MoneyTransferData, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<MoneyTransferData, int>));
    }
}
