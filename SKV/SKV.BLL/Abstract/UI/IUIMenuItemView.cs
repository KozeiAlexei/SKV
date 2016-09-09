using System.Collections.Generic;

using SKV.ML.ViewModels.Common;

namespace SKV.BLL.Abstract.UI
{
    public interface IUIMenuItemManager
    {
        IEnumerable<UIMenuItemView> GenerateMenuTree();
    }
}
