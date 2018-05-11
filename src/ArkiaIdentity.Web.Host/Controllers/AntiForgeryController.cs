using Microsoft.AspNetCore.Antiforgery;
using ArkiaIdentity.Controllers;

namespace ArkiaIdentity.Web.Host.Controllers
{
    public class AntiForgeryController : ArkiaIdentityControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
