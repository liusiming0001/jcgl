using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans.Dto
{
    public class AuditProductionPlanDto : EntityDto<long>
    {
        public int isAgree { get; set; }
    }
}
