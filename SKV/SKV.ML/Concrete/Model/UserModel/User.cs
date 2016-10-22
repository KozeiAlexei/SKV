using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using SKVUserModel = SKV.ML.Abstract.Model.UserModel;
using System.ComponentModel.DataAnnotations.Schema;
using SKV.ML.Metadata;

namespace SKV.ML.Concrete.Model.UserModel
{
    public class User : IdentityUser, SKVUserModel.IUser<string>
    {
        [Icon(IconClass = "glyphicon glyphicon-user form-control-feedback")]
        [Title(Source = ParameterSource.Resource)]
        public override string UserName { get; set; }

        [Icon(IconClass = "icon-mail-3 form-control-feedback")]
        [Title(Source = ParameterSource.Resource)]
        public override string Email { get; set; }

        [ForeignKey(nameof(Id))]
        public virtual UserProfile Profile { get; set; }

        public void CopyFrom(SKVUserModel.IUser<string> from) { }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string type = DefaultAuthenticationTypes.ApplicationCookie) =>
            await manager.CreateIdentityAsync(this, type);
    }
}
