using SKV.ML.Concrete.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.Abstract.Common
{
    public interface IPageManager
    {
        IEnumerable<Page> GetPages();

        Task<IEnumerable<Page>> GetPagesAsync();
    }
}
