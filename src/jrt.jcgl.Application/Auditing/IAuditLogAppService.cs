using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.Auditing.Dto;
using jrt.jcgl.Dto;

namespace jrt.jcgl.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultOutput<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);
    }
}