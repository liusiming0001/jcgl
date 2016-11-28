// File:    ProductionPlanAudit.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:57:35
// Purpose: Definition of Class ProductionPlanAudit

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using jrt.jcgl.Authorization.Roles;
using jrt.jcgl.Authorization.Users;
using System;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlanAudit : FullAuditedEntity<long>
    {
        /// <summary>
        /// 总计划ID
        /// </summary>
        public virtual long? ProductionPlanId { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public virtual long? AuditUserId { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public virtual int? AuditRoleId { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public AuditStatus Status { get; set; }
        /// <summary>
        /// 审核人实体
        /// </summary>
        public virtual User AuditUser { get; set; }
        /// <summary>
        /// 审核权限实体
        /// </summary>
        public virtual Role AuditRole { get; set; }
        /// <summary>
        /// 总计划ID
        /// </summary>
        public virtual ProductionPlan ProductionPlan { get; set; }
    }
}