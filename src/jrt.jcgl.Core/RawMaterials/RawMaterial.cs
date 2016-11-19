using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace jrt.jcgl.RawMaterials
{
    public class RawMaterial : FullAuditedEntity<int>
    {
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// ��Ӧ��
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// �����ȼ�
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// ������λ
        /// </summary>
        public UnitsType Units { get; set; }
        /// <summary>
        /// ҩƷ��س���
        /// </summary>
        public virtual ICollection<RawMaterialConstant> RawMaterialConstant { get; set; }
    }
}