using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.ProductionPlans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans
{
    public interface IProductionPlansAppService : IApplicationService
    {
        Task CreateProductionPlans(CreateProductionPlanDto input);
        ListResultDto<NameValueDto> GetSchedulingTypes();
        Task<PagedResultOutput<ProductionsHistoryListDto>> GetProductionPlansList(GetProductionHistoryListInput input);
        Task<ProductionPlanInfoDto> GetProductionPlanInfo(long id);
        Task AuditProductionPlan(AuditProductionPlanDto input);
        Task<PagedResultOutput<ProductionsHistoryListDto>> GetProductionPlansListFForAudit(GetProductionHistoryListInput input);
    }
}
