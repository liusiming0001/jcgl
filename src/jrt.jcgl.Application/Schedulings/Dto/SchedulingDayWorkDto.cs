using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings.Dto
{
    public class SchedulingDayWorkDto
    {
        /// <summary>
        /// 组名
        /// </summary>
        public string OrganzationName { get; set; }
        /// <summary>
        /// 成员名字
        /// </summary>
        public string MemberOneName { get; set; }
        public string MemberTwoName { get; set; }
        public string MemberThreeName { get; set; }
        /// <summary>
        /// 工作类型
        /// </summary>
        public WorkType WorkType { get; set; }
        /// <summary>
        /// 工种类型
        /// </summary>
        public MemberType MemberType { get; set; }
    }
    public enum MemberType
    {
        Extract,
        Membrane
    }
}
