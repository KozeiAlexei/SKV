using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class OperationStatusRepository : IOperationStatusRepository<OperationStatus, int, OperationType, int>
    {
        public IRepository<OperationStatus, int> Repository { get; } =
            (IRepository<OperationStatus, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<OperationStatus, int>));

        public OperationStatus GetStatusByTypeAndCode(OperationType type, int code) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.OperationType == type && e.StatusCode == code).FirstOrDefault());
    }
}
