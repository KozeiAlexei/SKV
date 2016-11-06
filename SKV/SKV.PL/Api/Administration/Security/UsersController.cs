using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json;
using SKV.BLL.Abstract.Identity;
using SKV.BLL.Identity;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SKV.PL.Api.Security
{
    [Authorize]
    [RoutePrefix("api/Administration/Security/Users")]
    public class UsersController : ApiControllerExt
    {
        private IIdentityUserManager<User, UserCreatingViewModel> UserManager { get; set; }

        public UsersController(IIdentityUserManager<User, UserCreatingViewModel> user_manager)
        {
            ThrowIfNull(user_manager, nameof(user_manager), postback: () => UserManager = user_manager);
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IHttpActionResult> GetUsers() => Json(await UserManager.GetUsersAsync());

        [HttpPost]
        [Route("UpdateUserData")]
        public async Task<IHttpActionResult> UpdateUserData(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.UpdateUserDataAsync(user);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserCreatingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.RegisterAsync(model);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(UserPasswordChangingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IHttpActionResult> DeleteUser(User user)
        {
            if(user.Id == null)
                ModelState.AddModelError(nameof(user.Id), "User identefier must be not null!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.DeleteUserAsync(user.Id);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [HttpGet]
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }
    }
}
