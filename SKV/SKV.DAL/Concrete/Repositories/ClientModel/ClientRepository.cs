using System.Linq;

using Ninject;

using SKV.DAL.Tools;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.ClientModel;
using SKV.DAL.Abstract.Repositories.ClientModel;

namespace SKV.DAL.Concrete.Repositories.ClientModel
{
    public class ClientRepository : IClientRepository<Client, int, int, string>
    {
        public IRepository<Client, int> Repository { get; } =
            (IRepository<Client, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Client, int>));

        public Client GetClientByPhone(string phone) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Phone == phone).FirstOrDefault());

        public string GetNextClientCode() =>
            ClientCodeGenerator.Generate(Repository.Sync.Synchronize(() => Repository.Table.OrderByDescending(e => e.Id).FirstOrDefault())?.Code);

        public bool IsExistClient(string phone) => (GetClientByPhone(phone) != null);
    }
}
