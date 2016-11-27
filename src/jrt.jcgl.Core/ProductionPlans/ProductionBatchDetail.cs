// File:    ProductionBatchDetail.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:58:22
// Purpose: Definition of Class ProductionBatchDetail

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using jrt.jcgl.RawMaterials;
using System;

namespace jrt.jcgl.ProductionPlans
{
    /// <summary>
    /// 生产计划批次明细
    /// </summary>
    public class ProductionBatchDetail : FullAuditedEntity<long>
    {
        /// <summary>
        /// 总计划ID
        /// </summary>
        public virtual long? ProductionPlanId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int SerailNum { get; set; }
        /// <summary>
        /// 药品Id
        /// </summary>
        public virtual int? RawMaterialId { get; set; }
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
        /// <summary>
        /// 原料
        /// </summary>
        public virtual RawMaterial RawMaterial { get; set; }
        /// <summary>
        /// 总计划实体
        /// </summary>
        public virtual ProductionPlan ProductionPlan { get; set; }
    }
}