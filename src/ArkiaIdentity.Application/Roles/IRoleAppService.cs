using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ArkiaIdentity.Roles.Dto;

namespace ArkiaIdentity.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
