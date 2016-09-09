using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.CallModel;
using SKV.DAL.Abstract.Repositories.CallModel;

namespace SKV.DAL.Concrete.Repositories.CallModel
{
    public class OperatorPhoneRepository : IOperatorPhoneRepository<OperatorPhone, int>
    {
        public IRepository<OperatorPhone, int> Repository { get; } =
            (IRepository<OperatorPhone, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<OperatorPhone, int>));

        public OperatorPhone GetOperatorPhoneByPhone(string phone) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.PhoneNumber == phone).FirstOrDefault());
    }
}
