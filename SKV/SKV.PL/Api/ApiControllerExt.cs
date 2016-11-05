using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SKV.PL.Api
{
    public class ApiControllerExt : ApiController
    {
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                        ModelState.AddModelError(string.Empty, error);
                }

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }

        protected void ThrowIfNull<TObject>(TObject obj, string name, Action postback) where TObject : class
        {
            if (obj == null)
                throw new ArgumentNullException(name);
            postback();
        }
    }
}