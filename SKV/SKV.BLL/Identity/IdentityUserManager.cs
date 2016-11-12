using System;
using System.Threading.Tasks;
using System.Collections.Generic;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;

using Ninject;

using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.EntityFramework;

using SKV.ML.ViewModels.Account;
using SKV.ML.Concrete.Model.UserModel;

using SKV.BLL.Abstract.Identity;

namespace SKV.BLL.Identity
{
    public class IdentityUserManager : IIdentityUserManager<User, UserCreatingViewModel>
    {
        private UserManager<User> UserManager { get; set; }

        private IDbManager DbManager { get; set; }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context) =>
            new IdentityUserManager(options, context);

        public IdentityUserManager(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            DbManager = DALDependencyResolver.Kernel.Get<IDbManager>();
            UserManager = new UserManager<User>(new UserStore<User>(DALDependencyResolver.Kernel.Get<DatabaseContext>()));

            UserManager.UserValidator = new UserValidator<User>(UserManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            UserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var data_protection_provider = options.DataProtectionProvider;
            if (data_protection_provider != null)
                UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(data_protection_provider.Create("DPP"));
        }

        public IdentityResult ChangePassword(string user_id, string old_password, string new_password) =>
            UserManager.ChangePassword(user_id, old_password, new_password);

        public async Task<IdentityResult> ChangePasswordAsync(string user_id, string old_password, string new_password) =>
            await UserManager.ChangePasswordAsync(user_id, old_password, new_password);

        private User UserCreatingModelPreparing(UserCreatingViewModel model)
        {
            return new User()
            {
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                Profile = new UserProfile()
                {
                    Name = model.Initials,
                    LastLoginDate = DateTime.Now,
                    RegistrationDate = DateTime.Now,
                    AsteriskId = (int)model.AsteriskId
                }
            };
        }

        public IdentityResult Register(UserCreatingViewModel model) =>
            UserManager.Create(UserCreatingModelPreparing(model), model.Password);

        public async Task<IdentityResult> RegisterAsync(UserCreatingViewModel model) =>
            await UserManager.CreateAsync(UserCreatingModelPreparing(model), model.Password);

        public async Task<OAuthUserModel> OAuthUserFindAsync(string user_name, string password)
        {
            var user = await UserManager.FindAsync(user_name, password);
            var oauth_user = default(OAuthUserModel);

            if (user != null)
            {
                oauth_user = new OAuthUserModel()
                {
                    OAuthIdentity = await user.GenerateUserIdentityAsync(UserManager, OAuthDefaults.AuthenticationType),
                    CookiesIdentity = await user.GenerateUserIdentityAsync(UserManager, CookieAuthenticationDefaults.AuthenticationType)
                };
            }

            return await Task.FromResult(oauth_user);
        }

        public IEnumerable<User> GetUsers() => DbManager.Users.GetUsers();

        public async Task<IEnumerable<User>> GetUsersAsync() => await Task.Run(() => GetUsers());

        private User PrepareUserUpdating(User identity_user, User user)
        {
            identity_user.Email = user.Email;
            identity_user.UserName = user.UserName;
            identity_user.PhoneNumber = user.PhoneNumber;

            identity_user.Profile.Name = user.Profile.Name;
            identity_user.Profile.AsteriskId = user.Profile.AsteriskId;

            return identity_user;
        }

        public IdentityResult UpdateUserData(User user) =>
            UserManager.Update(PrepareUserUpdating(UserManager.FindById(user.Id), user));

        public async Task<IdentityResult> UpdateUserDataAsync(User user) =>
            await UserManager.UpdateAsync(PrepareUserUpdating(await UserManager.FindByIdAsync(user.Id), user));

        private void DeleteUserProfile(string user_id)
        {
            DbManager.UserProfiles.Repository.Delete(user_id);
            DbManager.SaveChanges();
        }

        public IdentityResult DeleteUser(string user_id) =>
            Tools.ReturnWithAction(() => DeleteUserProfile(user_id), () => UserManager.Delete(UserManager.FindById(user_id)));

        public async Task<IdentityResult> DeleteUserAsync(string user_id) =>
            await Tools.ReturnWithAction(() => DeleteUserProfile(user_id), 
                                   async () => await UserManager.DeleteAsync(await UserManager.FindByIdAsync(user_id)));

        public void Dispose() => UserManager.Dispose();
    }
}
