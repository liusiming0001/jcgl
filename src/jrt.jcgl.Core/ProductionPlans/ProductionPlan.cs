// File:    ProductionPlan.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:56:17
// Purpose: Definition of Class ProductionPlan

using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlan : FullAuditedEntity<long>
    {
        /// <summary>
        /// 需求量
        /// </summary>
        public decimal Demand { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 审核日志
        /// </summary>
        public virtual ICollection<ProductionPlanAudit> ProductionPlanAudits { get; set; }
        public virtual ICollection<ProduictPlanLine> ProduictPlanLines { get; set; }
        public virtual ICollection<ProductionBatchDetail> ProductionBatchDetails { get; set; }
        public virtual ICollection<ProdutionPlanMain> ProdutionPlanMains { get; set; }
    }
}