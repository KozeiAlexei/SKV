using Microsoft.AspNet.Identity;
using SKV.ML.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.Abstract.Identity
{
    public interface IIdentityUserManager<TUser, TUserCreatingModel> : IDisposable
    {
        IEnumerable<TUser> GetUsers();

        IdentityResult Register(TUserCreatingModel model);
        IdentityResult DeleteUser(string user_id);
        IdentityResult ChangePassword(string user_id, string old_password, string new_password);
        IdentityResult UpdateUserData(TUser user);

        Task<IEnumerable<TUser>> GetUsersAsync();

        Task<IdentityResult> RegisterAsync(TUserCreatingModel model);
        Task<IdentityResult> DeleteUserAsync(string user_id);
        Task<IdentityResult> ChangePasswordAsync(string user_id, string old_password, string new_password);
        Task<IdentityResult> UpdateUserDataAsync(TUser user);

        Task<OAuthUserModel> OAuthUserFindAsync(string user_name, string password);
    }
}
