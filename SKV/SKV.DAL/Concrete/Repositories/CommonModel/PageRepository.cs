using System.Linq;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.CommonModel;
using SKV.DAL.Abstract.Repositories.CommonModel;

namespace SKV.DAL.Concrete.Repositories.CommonModel
{
    public class PageRepository : IPageRepository<Page, int>
    {
        public IRepository<Page, int> Repository { get; } =
            (IRepository<Page, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Page, int>));

        public Page GetPageByName(string name) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.Name == name).FirstOrDefault());

        public IEnumerable<string> GetPageNames() =>
            Repository.Sync.Synchronize(() => Repository.Table.Select(e => e.Name));
    }
}
