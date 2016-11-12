using SKV.BLL.Abstract.Identity;
using SKV.BLL.Identity;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.ViewModels.Administration.Security.Role;
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
    [RoutePrefix("api/Administration/Security/Roles")]
    public class RolesController : ApiControllerExt
    {
        private IIdentityRoleManager<UserRole> RoleManager { get; set; }

        public RolesController(IIdentityRoleManager<UserRole> role_manager)
        {
            ThrowIfNull(role_manager, nameof(role_manager), postback: () => RoleManager = role_manager);
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IHttpActionResult> GetRoles() => Json(await RoleManager.GetRolesAsync());

        [HttpPost]
        [Route("UpdateRoleData")]
        public async Task<IHttpActionResult> UpdateRoleData(UserRole role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await RoleManager.UpdateRoleDataAsync(role);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> CreateRole(RoleCreatingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await RoleManager.CreateAsync(model);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IHttpActionResult> DeleteRole(UserRole role)
        {
            if (role.Id == null)
                ModelState.AddModelError(nameof(role.Id), "Role identefier must be not null!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await RoleManager.DeleteRoleAsync(role.Id);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }
    }
}