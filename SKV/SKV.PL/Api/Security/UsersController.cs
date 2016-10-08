using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using SKV.BLL.Identity;
using SKV.ML.Concrete.Model.UserModel;
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
    [RoutePrefix("api/Security/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("GetUsers")]
        public IHttpActionResult GetUsers() =>
            Json(Request.GetOwinContext().GetUserManager<IdentityUserManager>().GetUsers());

        [HttpPost]
        [Route("UpdateUserData")]
        public async Task<IHttpActionResult> UpdateUserData(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await Request.GetOwinContext().GetUserManager<IdentityUserManager>().UpdateUserData(user);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
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
