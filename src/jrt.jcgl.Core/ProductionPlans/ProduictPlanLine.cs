// File:    ProduictPlanLine.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:56:50
// Purpose: Definition of Class ProduictPlanLine


using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using jrt.jcgl.ProductionPlans;
using System;

namespace jrt.jcgl.ProductionPlans
{
    public class ProduictPlanLine : FullAuditedEntity<long>
    {
        /// <summary>
        /// 总计划ID
        /// </summary>
        public virtual long ProductionPlanId { get; set; }
        /// <summary>
        /// 组织机构Id
        /// </summary>
        public virtual long OrganizationUnitId { get; set; }
        public virtual ProductionPlan ProdutionPlan { get; set; }
        public virtual OrganizationUnit OrganizationUnit { get; set; }
    }
}