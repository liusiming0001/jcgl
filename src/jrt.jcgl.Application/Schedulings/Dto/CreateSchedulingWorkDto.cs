using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings.Dto
{
    public class CreateSchedulingWorkDto
    {
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNum { get; set; }
        /// <summary>
        /// 提取工作内容
        /// </summary>
        public string ExtractWorkInfo { get; set; }
        /// <summary>
        /// 膜工作内容
        /// </summary>
        public string MembraneWorkInfo { get; set; }
        /// <summary>
        /// 药材名称
        /// </summary>
        public string MedicinalName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 预排班类型
        /// </summary>
        public SchedulingType Type { get; set; }
    }
}
