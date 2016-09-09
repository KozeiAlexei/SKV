using System.Collections.Generic;

using Ninject;

using SKV.DAL;
using SKV.DAL.Abstract.Database;

using SKV.BLL.Abstract.UI;

using SKV.ML.Concrete.Model.UIModel;

namespace SKV.BLL.UI
{
    public class UICultureManager : IUICultureManager
    {
        private IDbManager db_manager = DALDependencyResolver.Kernel.Get<IDbManager>();

        public IEnumerable<UICulture> GetUICultures() => db_manager.UICultures.Repository.Read();

        public UICulture GetDefaultCulture() => db_manager.SystemSettings.GetSystemSettings().DefaultUICultureInstance;

    }
}
