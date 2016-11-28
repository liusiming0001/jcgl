using Abp.Runtime.Validation;
using jrt.jcgl.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans.Dto
{
    public class GetProductionHistoryListInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public DateTime? StartDate { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
