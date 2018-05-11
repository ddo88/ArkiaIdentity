using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ArkiaIdentity.Roles.Dto;
using ArkiaIdentity.Users.Dto;

namespace ArkiaIdentity.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
