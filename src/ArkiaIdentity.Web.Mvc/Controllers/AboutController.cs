using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ArkiaIdentity.Controllers;

namespace ArkiaIdentity.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ArkiaIdentityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
