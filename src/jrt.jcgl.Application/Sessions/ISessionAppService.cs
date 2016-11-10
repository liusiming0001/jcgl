using System.Threading.Tasks;
using Abp.Application.Services;
using jrt.jcgl.Sessions.Dto;

namespace jrt.jcgl.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
