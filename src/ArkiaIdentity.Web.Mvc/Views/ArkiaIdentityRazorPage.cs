using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace ArkiaIdentity.Web.Views
{
    public abstract class ArkiaIdentityRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ArkiaIdentityRazorPage()
        {
            LocalizationSourceName = ArkiaIdentityConsts.LocalizationSourceName;
        }
    }
}
