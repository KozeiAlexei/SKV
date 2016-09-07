using System;

using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

using SKV.PL.Providers;
using SKV.BLL.Identity;

namespace SKV.PL
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                Provider = new ApplicationOAuthProvider(PublicClientId),
                TokenEndpointPath = new PathString("/Token"),
                AllowInsecureHttp = false,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14)
            };

            IdentityConfigurator.ConfigureAuth(app, OAuthOptions);
        }
    }
}
