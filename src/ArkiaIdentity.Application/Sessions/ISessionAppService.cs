using System.Threading.Tasks;
using Abp.Application.Services;
using ArkiaIdentity.Sessions.Dto;

namespace ArkiaIdentity.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
