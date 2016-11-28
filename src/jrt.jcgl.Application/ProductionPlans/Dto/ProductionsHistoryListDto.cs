using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans.Dto
{
    [AutoMapFrom(typeof(ProductionPlan))]
    public class ProductionsHistoryListDto:EntityDto<long>
    {
        public string CreateUserName { get; set; }
        public decimal Demand { get; set; }
        public DateTime StartDate { get; set; }
        public AuditStatus AuditStatus { get; set; }
    }
}
