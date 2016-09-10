﻿using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using SKV.BLL.Identity;
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
    public class UsersController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetUsers() =>
            Json(Request.GetOwinContext().GetUserManager<IdentityUserManager>().GetUsers());
    }
}
