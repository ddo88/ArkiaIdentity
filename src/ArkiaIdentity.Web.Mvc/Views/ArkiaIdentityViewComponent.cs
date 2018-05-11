using Abp.AspNetCore.Mvc.ViewComponents;

namespace ArkiaIdentity.Web.Views
{
    public abstract class ArkiaIdentityViewComponent : AbpViewComponent
    {
        protected ArkiaIdentityViewComponent()
        {
            LocalizationSourceName = ArkiaIdentityConsts.LocalizationSourceName;
        }
    }
}
