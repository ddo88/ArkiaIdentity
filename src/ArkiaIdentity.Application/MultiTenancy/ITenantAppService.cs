using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ArkiaIdentity.MultiTenancy.Dto;

namespace ArkiaIdentity.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
