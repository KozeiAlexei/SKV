using SKV.DAL.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Abstract.Model.UserModel
{
    public interface IUser<TKey> : IEntity<TKey>, ICloneableFrom<IUser<TKey>>
    {
    }
}
