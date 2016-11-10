using System.Threading.Tasks;
using Abp.Application.Services;
using jrt.jcgl.Configuration.Tenants.Dto;

namespace jrt.jcgl.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);
    }
}
