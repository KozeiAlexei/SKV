using SKV.BLL.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKV.ML.Concrete.Model.CommonModel;
using SKV.DAL.Abstract.Database;
using SKV.DAL;
using Ninject;

namespace SKV.BLL.Common
{
    public class PageManager : IPageManager
    {
        private IDbManager DbManager { get; set; }

        public PageManager()
        {
            DbManager = DALDependencyResolver.Kernel.Get<IDbManager>();
        }

        public PageManager(IDbManager dbManager)
        {
            DbManager = dbManager;
        }

        public IEnumerable<Page> GetPages() => DbManager.Pages.Repository.Read();

        public async Task<IEnumerable<Page>> GetPagesAsync() => await Task.Run(() => GetPages());
    }
}
