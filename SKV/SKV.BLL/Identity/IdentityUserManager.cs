using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using SKV.DAL;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.EntityFramework;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SKV.BLL.Identity
{
    public class IdentityUserManager : IDisposable
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


        public async Task<IdentityResult> ChangePasswordAsync(string user_id, string old_password, string new_password) =>
            await UserManager.ChangePasswordAsync(user_id, old_password, new_password);

        public async Task<IdentityResult> RegisterAsync(RegisterAccountViewModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                Profile = new UserProfile()
                {
                    Name = model.Initials,
                    LastLoginDate = DateTime.Now,
                    RegistrationDate = DateTime.Now,
                    AsteriskId = (int)model.AsteriskUniqueId
                }
            };


            return await UserManager.CreateAsync(user, model.Password);
        }

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

        public async Task<IEnumerable<User>> GetUsers() => await Task.Run(() => DbManager.Users.GetUsers());

        public async Task<IdentityResult> UpdateUserData(User user)
        {
            var identity_user = UserManager.FindById(user.Id);

            identity_user.UserName = user.UserName;
            identity_user.Email = user.Email;
            identity_user.PhoneNumber = user.PhoneNumber;
            identity_user.Profile.Name = user.Profile.Name;

            return await UserManager.UpdateAsync(identity_user);
        }

        public void Dispose() => UserManager.Dispose();
    }
}
