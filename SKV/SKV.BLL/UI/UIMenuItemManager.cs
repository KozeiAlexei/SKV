using Ninject;
using SKV.BLL.Abstract.UI;
using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.UIModel;
using SKV.VML.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.UI
{
    public class UIMenuItemManager : IUIMenuItemManager
    {
        private IDbManager db_manager = DALDependencyResolver.Kernel.Get<IDbManager>();

        public IEnumerable<UIMenuItemView> GenerateMenuTree()
        {
            foreach (var item in GetChildItems(DALStaticData.UIMenuItemTopParentId))
                yield return MakeParent(item);
        }

        private UIMenuItemView MakeParent(UIMenuItem menu_item)
        {
            var cur_step = Adapter(menu_item);
            foreach (var item in GetChildItems(menu_item.Id))
            {
                if (GetChildItems(item.Id).Any())
                    cur_step.Childs.Add(MakeParent(item));
                else
                    cur_step.Childs.Add(Adapter(item));
            }

            return cur_step;
        }

        private UIMenuItemView Adapter(UIMenuItem item)
        {
            return new UIMenuItemView()
            {
                Name = item.Name,
                Action = item.Action,
                Location = item.Location,
                IconClass = item.IconClass,
                Controller = item.Controller
            };
        }

        private IEnumerable<UIMenuItem> GetChildItems(int? parent_id) =>
            db_manager.UIMenuItems.Repository.Read().Where(e => e.ParentId == parent_id).OrderBy(e => e.Location);
    }
}
