using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SKV.PL.Models;
using SKV.BLL.Identity;

namespace SKV.PL.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string public_client_id;

        public ApplicationOAuthProvider(string public_client_id)
        {
            if (public_client_id == null)
                throw new ArgumentNullException("public_client_id");

            this.public_client_id = public_client_id;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user_manager = context.OwinContext.GetUserManager<IdentityUserManager>();

            var oauth_user = await user_manager.OAuthUserFindAsync(context.UserName, context.Password);

            if (oauth_user == null)
            {
                context.SetError("invalid_grant", "Имя пользователя или пароль указаны неправильно.");
                return;
            }

            AuthenticationProperties properties = CreateProperties(context.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oauth_user.OAuthIdentity, properties);

            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(oauth_user.CookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == public_client_id)
            {
                var expected_root_uri = new Uri(context.Request.Uri, "/");

                if (expected_root_uri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string user_name)
        {
            return new AuthenticationProperties(new Dictionary<string, string>
            {
                { "UserName", user_name }
            });
        }
    }
}