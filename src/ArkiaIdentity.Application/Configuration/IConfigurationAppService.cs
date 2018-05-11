using System.Threading.Tasks;
using ArkiaIdentity.Configuration.Dto;

namespace ArkiaIdentity.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
