using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.CallModel;
using SKV.DAL.Abstract.Repositories.CallModel;

namespace SKV.DAL.Concrete.Repositories.CallModel
{
    public class CallRepository : ICallRepository<Call, int, CallType>
    {
        public IRepository<Call, int> Repository { get; } = (IRepository<Call, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Call, int>));

        public Call GetCallByAsteriskUniqueId(string id) => 
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.AsteriskUniqueId == id).FirstOrDefault());      
    }
}
