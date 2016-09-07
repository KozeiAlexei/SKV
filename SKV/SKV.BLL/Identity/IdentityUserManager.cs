using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

using SKV.DAL.Concrete.EntityFramework;
using SKV.DAL.Concrete.Model.UserModel;

namespace SKV.BLL.Identity
{
    public class IdentityUserManager : UserManager<User>
    {
        public IdentityUserManager(IUserStore<User> store) : base(store) { }


        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            var manager = new IdentityUserManager(new UserStore<User>(context.Get<DatabaseContext>()));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var data_protection_provider = options.DataProtectionProvider;
            if (data_protection_provider != null)
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(data_protection_provider.Create("SKVAutomatisation 2.0"));

            return manager;
        }
    }
}
