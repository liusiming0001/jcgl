using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using jrt.jcgl.ProductionPlans.Dto;
using jrt.jcgl.Schedulings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jrt.jcgl.Authorization.Roles;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlansAppService : AbpZeroTemplateAppServiceBase, IProductionPlansAppService
    {

        private readonly RoleManager _roleManager;
        private readonly IProductionPlanManager _productionPlanManager;
        private readonly IRepository<ProductionPlan, long> _productionPlanRepository;
        private readonly IRepository<ProductionPlanAudit, long> _productionPlanAuditRepository;
        public ProductionPlansAppService(
            IProductionPlanManager _productionPlanManager,
            IRepository<ProductionPlan, long> _productionPlanRepository,
            RoleManager _roleManager,
            IRepository<ProductionPlanAudit, long> _productionPlanAuditRepository
            )
        {
            this._productionPlanManager = _productionPlanManager;
            this._productionPlanRepository = _productionPlanRepository;
            this._roleManager = _roleManager;
            this._productionPlanAuditRepository = _productionPlanAuditRepository;
        }

        public async Task CreateProductionPlans(CreateProductionPlanDto input)
        {
            try
            {
                await _productionPlanManager.FormulateProdutionPlan(
                        input.Value * 1000,
                        input.StartDateTime,
                        input.Organzations,
                        input.RestType
                    );
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }
        public ListResultDto<NameValueDto> GetSchedulingTypes()
        {
            return EnumToNameValueList<SchedulingType>();
        }
        public async Task<PagedResultOutput<ProductionsHistoryListDto>> GetProductionPlansList(GetProductionHistoryListInput input)
        {
            try
            {

                var query = _productionPlanRepository.GetAll()
                    .WhereIf(!input.Filter.IsNullOrWhiteSpace(), p => p.CreatorUser.Name.Contains(input.Filter))
                    .WhereIf(input.StartDate.HasValue, p => p.StartDate == input.StartDate);
                var items = from p in query
                            select new ProductionsHistoryListDto
                            {
                                Id = p.Id,
                                StartDate = p.StartDate,
                                Demand = p.Demand,
                                AuditStatus = p.AuditStatus,
                                CreateUserName = p.CreatorUser.Name
                            };

                var count = await query.CountAsync();


                return new PagedResultOutput<ProductionsHistoryListDto>(count, items.ToList());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ProductionPlanInfoDto> GetProductionPlanInfo(long id)
        {
            try
            {
                ProductionPlanInfoDto output = new ProductionPlanInfoDto();

                var productionplan = await _productionPlanRepository.FirstOrDefaultAsync(id);

                output.ProductionPlan = new ProductionPlanDto
                {
                    StartDate = productionplan.StartDate.Date,
                    Demand = productionplan.Demand,
                    CreateUserName = productionplan.CreatorUser.Name,
                    AuditStatus = productionplan.AuditStatus
                };

                output.ProductionMain = (from p in productionplan.ProdutionPlanMains
                                         select new ProductionMainDto
                                         {
                                             SerialNumber = p.SerialNumber,
                                             PlannedQuantity = p.PlannedQuantity,
                                             StockQuantity = p.StockQuantity,
                                             ProductionQuantity = p.ProductionQuantity,
                                             PS = p.PS,
                                             RawMaterialRequirement = p.RawMaterialRequirement,
                                             RawMaterialName = p.RawMaterial.Name
                                         }).ToList();

                output.ProductionPlanDetails = (from p in productionplan.ProductionBatchDetails
                                                select new ProductionPlanDetailDto
                                                {
                                                    SerailNum = p.SerailNum,
                                                    RawMaterialName = p.RawMaterial.Name,
                                                    BatchNum = p.BatchNum,
                                                    ProductionLine = p.ProductionLine,
                                                    MissionQuantity = p.MissionQuantity,
                                                    BatchQuantity = p.BatchQuantity,
                                                    MissionDate = p.MissionDate,
                                                    CYL = p.CYL,
                                                    SGL = p.SGL
                                                }).ToList();

                output.ProductionLines = (from p in productionplan.ProduictPlanLines
                                          select new ProductionLinesDto
                                          {
                                              OrganizationUnitName = p.OrganizationUnit.DisplayName
                                          }).ToList();

                return output;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task AuditProductionPlan(AuditProductionPlanDto input)
        {
            var userrole = GetCurrentUser().Roles.FirstOrDefault();
            var role = await _roleManager.FindByIdAsync(userrole.RoleId);
            var production = await _productionPlanRepository.FirstOrDefaultAsync(input.Id);
            switch (role.Name)
            {
                case StaticRoleNames.Tenants.WorkShopDirector:
                    if (input.isAgree == 0)
                        production.AuditStatus = AuditStatus.WorkshopDirectorPass;
                    else
                        production.AuditStatus = AuditStatus.WorkshopDirectorUnPass;
                    break;
                case StaticRoleNames.Tenants.GeneralManagement:
                    if (input.isAgree == 0)
                        production.AuditStatus = AuditStatus.GeneralManagementPass;
                    else
                        production.AuditStatus = AuditStatus.GeneralManagementUnPass;
                    break;
                default:
                    throw new UserFriendlyException("你没有权限审核生产计划");
                    break;
            }
            await _productionPlanRepository.UpdateAsync(production);
            await _productionPlanAuditRepository.InsertAsync(new ProductionPlanAudit
            {
                ProductionPlanId = production.Id,
                AuditUserId = GetCurrentUser().Id,
                AuditRoleId = role.Id,
                AuditTime = DateTime.Now,
                Status = production.AuditStatus
            });
        }

        public async Task<PagedResultOutput<ProductionsHistoryListDto>> GetProductionPlansListFForAudit(GetProductionHistoryListInput input)
        {
            try
            {
                var userrole = GetCurrentUser().Roles.FirstOrDefault();
                var role = await _roleManager.FindByIdAsync(userrole.RoleId);

                var query = _productionPlanRepository.GetAll()
                    .WhereIf(role.Name== StaticRoleNames.Tenants.WorkShopDirector, p => 
                    p.AuditStatus==AuditStatus.Submitted || 
                    p.AuditStatus == AuditStatus.WorkshopDirectorPass || 
                    p.AuditStatus == AuditStatus.WorkshopDirectorUnPass)
                    .WhereIf(role.Name == StaticRoleNames.Tenants.GeneralManagement, p =>
                     p.AuditStatus == AuditStatus.GeneralManagementPass ||
                     p.AuditStatus == AuditStatus.GeneralManagementPass ||
                     p.AuditStatus == AuditStatus.WorkshopDirectorPass)
                    .WhereIf(!input.Filter.IsNullOrWhiteSpace(), p => p.CreatorUser.Name.Contains(input.Filter))
                    .WhereIf(input.StartDate.HasValue, p => p.StartDate == input.StartDate);
                var items = from p in query
                            select new ProductionsHistoryListDto
                            {
                                Id = p.Id,
                                StartDate = p.StartDate,
                                Demand = p.Demand,
                                AuditStatus = p.AuditStatus,
                                CreateUserName = p.CreatorUser.Name
                            };

                var count = await query.CountAsync();


                return new PagedResultOutput<ProductionsHistoryListDto>(count, items.ToList());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
