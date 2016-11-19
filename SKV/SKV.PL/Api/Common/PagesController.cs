using SKV.BLL.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SKV.PL.Api.Common
{
    [Authorize]
    [RoutePrefix("api/Common/Pages")]
    public class PagesController : ApiControllerExt
    {
        private IPageManager PageManager { get; set; }

        public PagesController(IPageManager pageManager)
        {
            ThrowIfNull(pageManager, nameof(pageManager), () => PageManager = pageManager);
        }

        [HttpGet]
        [Route("GetPages")]
        public async Task<IHttpActionResult> GetPages() => Json(await PageManager.GetPagesAsync());
    }
}
