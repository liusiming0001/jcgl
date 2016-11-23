using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.RawMaterials.Dto
{
    [AutoMapFrom(typeof(RawMaterialConstant))]
    [AutoMapTo(typeof(RawMaterialConstant))]
    public class RawMaterialConstantDto:EntityDto
    {
        /// <summary>
        /// 药品
        /// </summary>
        public virtual int RawMaterialId { get; set; }
        /// <summary>
        /// 常数名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 常数类型
        /// </summary>
        public RawMaterialConstantType Type { get; set; }
        /// <summary>
        /// 常数
        /// </summary>
        public decimal Constant { get; set; }
    }
}
