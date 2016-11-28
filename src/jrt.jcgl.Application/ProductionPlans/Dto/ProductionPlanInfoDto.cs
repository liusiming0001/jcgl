using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans.Dto
{
    public class ProductionPlanInfoDto
    {
        public ProductionPlanDto ProductionPlan { get; set; }
        public List<ProductionPlanDetailDto> ProductionPlanDetails { get; set; }

        public List<ProductionMainDto> ProductionMain { get; set; }

        public List<ProductionLinesDto> ProductionLines { get; set; }
    }

    public class ProductionPlanDetailDto
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int SerailNum { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string RawMaterialName { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNum { get; set; }
        /// <summary>
        /// 生产线
        /// </summary>
        public string ProductionLine { get; set; }
        /// <summary>
        /// 任务量
        /// </summary>
        public decimal MissionQuantity { get; set; }
        /// <summary>
        /// 批次生产量
        /// </summary>
        public decimal BatchQuantity { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime MissionDate { get; set; }
        /// <summary>
        /// 出药量
        /// </summary>
        public decimal CYL { get; set; }
        /// <summary>
        /// 收膏率 
        /// </summary>
        public decimal SGL { get; set; }
    }

    public class ProductionMainDto
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 计划任务量
        /// </summary>
        public decimal PlannedQuantity { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StockQuantity { get; set; }
        /// <summary>
        ///实际生产量
        /// </summary>
        public decimal ProductionQuantity { get; set; }
        /// <summary>
        /// 批数
        /// </summary>
        public int PS { get; set; }
        /// <summary>
        /// 原料需求量
        /// </summary>
        public decimal RawMaterialRequirement { get; set; }
        /// <summary>
        /// 原料名称
        /// </summary>
        public string RawMaterialName { get; set; }
    }

    public class ProductionLinesDto
    {
        public string OrganizationUnitName { get; set; }
    }

    public class ProductionPlanDto
    {
        public string CreateUserName { get; set; }
        public decimal Demand { get; set; }
        public DateTime StartDate { get; set; }
        public AuditStatus AuditStatus { get; set; }
    }
}
