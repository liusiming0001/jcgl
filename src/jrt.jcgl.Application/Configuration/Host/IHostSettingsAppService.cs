using System.Threading.Tasks;
using Abp.Application.Services;
using jrt.jcgl.Configuration.Host.Dto;

namespace jrt.jcgl.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);
    }
}
