using Abp.Application.Services;
using jrt.jcgl.Tenants.Dashboard.Dto;

namespace jrt.jcgl.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
