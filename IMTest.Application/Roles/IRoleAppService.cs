using System.Threading.Tasks;
using Abp.Application.Services;
using IMTest.Roles.Dto;

namespace IMTest.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
