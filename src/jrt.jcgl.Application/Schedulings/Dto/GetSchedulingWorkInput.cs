using Abp.Extensions;
using Abp.Runtime.Validation;
using Abp.Timing;
using jrt.jcgl.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings.Dto
{
    public class GetSchedulingWorkInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "SchedulingDate";
            }
        }
    }
}
