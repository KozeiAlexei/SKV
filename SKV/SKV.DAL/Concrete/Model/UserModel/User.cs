using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SKVUserModel = SKV.DAL.Abstract.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.UserModel
{
    public class User : IdentityUser, SKVUserModel.IUser<string>
    {
        public virtual UserProfile Profile { get; set; }

        public void CopyFrom(SKVUserModel.IUser<string> from) { }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager) 
            => await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    }
}
