using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.RawMaterials.Dto
{
    [AutoMapTo(typeof(RawMaterial))]
    [AutoMapFrom(typeof(RawMaterial))]
    public class CreateOrUpdateDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }
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
        /// 常数
        /// </summary>
        public List<RawMaterialConstantDto> Constant { get; set; } = new List<RawMaterialConstantDto>();
    }
}
