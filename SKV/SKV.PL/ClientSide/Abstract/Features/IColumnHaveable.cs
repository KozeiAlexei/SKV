using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.PL.ClientSide.Abstract.Features
{
    public interface IColumnHaveable<TComponent>
    {
        TComponent Columns(Action<IContainer> columns);
    }
}
