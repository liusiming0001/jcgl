using Abp.Domain.Entities;
using Abp.Organizations;
using System;

namespace jrt.jcgl.Schedulings
{
    public class Scheduling : Entity<long>
    {
        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime SchedulingDate { get; set; }
        /// <summary>
        /// 提取批号
        /// </summary>
        public string ExtractBatchNum { get; set; }
        /// <summary>
        /// 提取组
        /// </summary>
        public virtual long? ExtractMemberId{get;set;}
        public virtual OrganizationUnit ExtractMember { get; set; }
        /// <summary>
        /// 提取工作内容
        /// </summary>
        public string ExtractWorkInfo { get; set; }
        /// <summary>
        /// 膜批号
        /// </summary>
        public string MembraneBatchNum { get; set; }
        /// <summary>
        /// 膜组
        /// </summary>
        public virtual long? MembraneMemberId { get; set; }
        public virtual OrganizationUnit MembraneMember { get; set; }
        /// <summary>
        /// 膜工作内容
        /// </summary>
        public string MembraneWorkInfo { get; set; }
        /// <summary>
        /// 药材名称
        /// </summary>
        public string MedicinalName { get; set; }
        /// <summary>
        /// 工作类型
        /// </summary>
        public WorkType WorkType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
    public enum WorkType
    {
        Day,
        Middle,
        Night
    }
}
