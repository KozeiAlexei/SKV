using System.Collections.Generic;

using SKV.VML.ViewModels.Common;

namespace SKV.BLL.Abstract.UI
{
    public interface IUICultureManager
    {
        IEnumerable<UICultureView> GetUICultures();

        UICultureView GetDefaultCulture();
    }
}
