using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ArkiaIdentity.Controllers
{
    public abstract class ArkiaIdentityControllerBase: AbpController
    {
        protected ArkiaIdentityControllerBase()
        {
            LocalizationSourceName = ArkiaIdentityConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
