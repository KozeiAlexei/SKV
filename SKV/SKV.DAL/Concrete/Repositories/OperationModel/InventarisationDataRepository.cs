using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class InventarisationDataRepository : IInventarisationDataRepository<InventarisationData, int, int, int, int, decimal>
    {
        public IRepository<InventarisationData, int> Repository { get; } =
            (IRepository<InventarisationData, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<InventarisationData, int>));
    }
}
