using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ArkiaIdentity.Configuration.Dto;

namespace ArkiaIdentity.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ArkiaIdentityAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
