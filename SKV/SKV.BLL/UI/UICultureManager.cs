using System.Collections.Generic;

using Ninject;

using SKV.DAL;
using SKV.DAL.Abstract.Database;

using SKV.BLL.Abstract.UI;

using SKV.VML.ViewModels.Common;

namespace SKV.BLL.UI
{
    public class UICultureManager : IUICultureManager
    {
        private IDbManager db_manager = DALDependencyResolver.Kernel.Get<IDbManager>();

        public IEnumerable<UICultureView> GetUICultures()
        {
            foreach (var lang in db_manager.UICultures.Repository.Read())
                yield return new UICultureView() { Name = lang.Name, Culture = lang.Culture };
        }

        public UICultureView GetDefaultCulture()
        {
            var ui_cilture = db_manager.SystemSettings.GetSystemSettings().DefaultUICultureInstance;
            return new UICultureView() { Name = ui_cilture.Name, Culture = ui_cilture.Culture };
        }

    }
}
