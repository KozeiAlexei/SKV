using System.Linq;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.ClientModel;
using SKV.DAL.Abstract.Repositories.ClientModel;

namespace SKV.DAL.Concrete.Repositories.ClientModel
{
    public class ClientStatusRepository : IClientStatusRepository<ClientStatus, int, ClientStatusCode>
    {
        public IRepository<ClientStatus, int> Repository { get; } =
            (IRepository<ClientStatus, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<ClientStatus, int>));

        public ClientStatus GetStatusByCode(ClientStatusCode code) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Code == code).FirstOrDefault());
    }
}
