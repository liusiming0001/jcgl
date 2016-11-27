// File:    RawMaterialConstant.cs
// Author:  RD-LSM
// Created: 2016年11月18日 20:07:17
// Purpose: Definition of Class RawMaterialConstant

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using jrt.jcgl.RawMaterials;
using System;

namespace jrt.jcgl.RawMaterials
{
    public class RawMaterialConstant : FullAuditedEntity<int>
    {
        /// <summary>
        /// 药品
        /// </summary>
        public virtual int? RawMaterialId { get; set; }
        /// <summary>
        /// 常数类型
        /// </summary>
        public RawMaterialConstantType Type { get; set; }
        /// <summary>
        /// 常数
        /// </summary>
        public decimal Constant { get; set; }
        /// <summary>
        /// 药品
        /// </summary>
        public virtual RawMaterial RawMaterial { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }

    }
}