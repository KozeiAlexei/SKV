using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Abstract.Repositories.UserModel
{
    public interface IUserProfileRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IUserProfile<TKey>
    {
    }
}
