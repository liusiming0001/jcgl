// File:    ProductionPlanAudit.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:57:35
// Purpose: Definition of Class ProductionPlanAudit

using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlanAudit : Entity<long>
    {
        public long auditUserId { get; set; }
        public DateTime auditTime { get; set; }
        public int status { get; set; }

    }
}