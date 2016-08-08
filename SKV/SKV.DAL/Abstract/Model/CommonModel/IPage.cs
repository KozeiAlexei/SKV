using SKV.DAL.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Abstract.Model.CommonModel
{
    public interface IPage<TKey> : IEntity<TKey>, ICloneableFrom<IPage<TKey>>
    { 
        string URL { get; set; }

        string Name { get; set; }
    }
}
