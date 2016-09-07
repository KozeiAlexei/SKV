using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SKV.PL.Models;
using SKV.PL.Providers;
using SKV.PL.Results;
using SKV.PL;
using SKV.BLL.Identity;
using SKV.VML.ViewModels.Account;

namespace SKV.Api.Security
{
    [Authorize]
    [RoutePrefix("api/Security/Account")]
    public class AccountController : ApiController
    {
        private IdentityUserManager user_manager;


        public AccountController() { }

        public AccountController(IdentityUserManager user_manager, ISecureDataFormat<AuthenticationTicket> access_token_format)
        {
            UserManager = user_manager;
            AccessTokenFormat = access_token_format;
        }


        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        public IdentityUserManager UserManager
        {
            get { return user_manager ?? Request.GetOwinContext().GetUserManager<IdentityUserManager>(); }
            private set { user_manager = value; }
        }


        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }


        [Route("Register")] [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.RegisterAsync(model);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && user_manager != null)
            {
                user_manager.Dispose();
                user_manager = null;
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                        ModelState.AddModelError("", error);
                }

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
