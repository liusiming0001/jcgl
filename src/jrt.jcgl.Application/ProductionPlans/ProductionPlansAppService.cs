using Abp.Application.Services.Dto;
using Abp.UI;
using jrt.jcgl.ProductionPlans.Dto;
using jrt.jcgl.Schedulings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlansAppService : AbpZeroTemplateAppServiceBase, IProductionPlansAppService
    {
        private readonly IProductionPlanManager _productionPlanManager;

        public ProductionPlansAppService(IProductionPlanManager _productionPlanManager)
        {
            this._productionPlanManager = _productionPlanManager;
        }

        public async Task CreateProductionPlans(CreateProductionPlanDto input)
        {
            try
            {
                await _productionPlanManager.FormulateProdutionPlan(
                        input.Value,
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
    }
}
