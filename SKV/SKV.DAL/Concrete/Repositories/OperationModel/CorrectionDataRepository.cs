using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class CorrectionDataRepository : ICorrectionDataRepository<CorrectionData, int, int, int, int>
    {
        public IRepository<CorrectionData, int> Repository { get; } =
            (IRepository<CorrectionData, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<CorrectionData, int>));
    }
}
