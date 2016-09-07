using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using System.Security.Principal;
using System.Security.Claims;
using SKV.DAL;
using Ninject;
using SKV.DAL.Abstract.Database;

namespace SKV.BLL.Identity
{
    public static class IdentityExt
    {
        public static string GetUserFirstName(this IIdentity identity)
        {
            return DALDependencyResolver.Kernel.Get<IDbManager>().UserProfiles.GetUserProfileById(identity.GetUserId()).Name;
        }
        
    }
}
