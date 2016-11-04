using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.PL.ClientSide.Abstract
{
    public interface ILocalizedDataProvider<TKey, TValue>
    {
        TValue GetLocalizedData(TKey key);
    }
}
