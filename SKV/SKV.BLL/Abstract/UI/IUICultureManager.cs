using System.Collections.Generic;

using SKV.ML.Concrete.Model.UIModel;

namespace SKV.BLL.Abstract.UI
{
    public interface IUICultureManager
    {
        IEnumerable<UICulture> GetUICultures();

        UICulture GetDefaultCulture();
    }
}
