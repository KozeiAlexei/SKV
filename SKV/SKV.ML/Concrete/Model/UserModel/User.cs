using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using SKVUserModel = SKV.ML.Abstract.Model.UserModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKV.ML.Concrete.Model.UserModel
{
    public class User : IdentityUser, SKVUserModel.IUser<string>
    {
        [ForeignKey(nameof(Id))]
        public virtual UserProfile Profile { get; set; }

        public void CopyFrom(SKVUserModel.IUser<string> from) { }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string type = DefaultAuthenticationTypes.ApplicationCookie) =>
            await manager.CreateIdentityAsync(this, type);
    }
}
