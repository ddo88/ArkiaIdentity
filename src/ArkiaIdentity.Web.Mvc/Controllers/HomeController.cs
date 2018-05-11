using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ArkiaIdentity.Controllers;

namespace ArkiaIdentity.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ArkiaIdentityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
