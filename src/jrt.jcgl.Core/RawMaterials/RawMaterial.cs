using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace jrt.jcgl.RawMaterials
{
    public class RawMaterial : FullAuditedEntity<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// 质量等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public UnitsType Units { get; set; }
        /// <summary>
        /// 药品相关常数
        /// </summary>
        public virtual ICollection<RawMaterialConstant> RawMaterialConstant { get; set; }
    }
}