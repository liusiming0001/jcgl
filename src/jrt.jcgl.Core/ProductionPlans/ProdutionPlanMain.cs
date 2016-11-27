// File:    ProdutionPlanMain.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:59:54
// Purpose: Definition of Class ProdutionPlanMain

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using jrt.jcgl.RawMaterials;
using jrt.jcgl.Stocks;
using System;
using System.Collections.Generic;

namespace jrt.jcgl.ProductionPlans
{
    public class ProdutionPlanMain : FullAuditedEntity<long>
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber { get; set; }
        public virtual long? ProductionPlanId { get; set; }
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
        /// 库存ID
        /// </summary>
        public virtual int? StockId { get; set; }
        /// <summary>
        /// 原料ID
        /// </summary>
        public virtual int? RawMaterialId { get; set; }
        /// <summary>
        /// 库存实体
        /// </summary>
        public virtual Stock Stock { get; set; }
        /// <summary>
        /// 原料实体
        /// </summary>
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual ProductionPlan ProductionPlan { get; set; }
    }
}