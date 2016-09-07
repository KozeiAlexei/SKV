using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;

using SKV.DAL.Concrete.EntityFramework;

namespace SKV.BLL.Identity
{
    public static class IdentityConfigurator
    {
        public static void ConfigureAuth(IAppBuilder app, OAuthAuthorizationServerOptions oauth_options)
        {
            app.CreatePerOwinContext(DatabaseContext.Create);
            app.CreatePerOwinContext<IdentityUserManager>(IdentityUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOAuthBearerTokens(oauth_options);
        }
    }
}
