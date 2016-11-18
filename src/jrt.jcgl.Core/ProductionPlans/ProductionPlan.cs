// File:    ProductionPlan.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:56:17
// Purpose: Definition of Class ProductionPlan

using Abp.Domain.Entities.Auditing;
using System;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlan : FullAuditedEntity<long>
    {
        public int demand { get; set; }
        public DateTime starDate { get; set; }

        public System.Collections.Generic.List<ProductionPlanAudit> productionPlanAudit { get; set; }
    }
}