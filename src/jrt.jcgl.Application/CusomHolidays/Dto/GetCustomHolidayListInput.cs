using Abp.Runtime.Validation;
using jrt.jcgl.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.CusomHolidays.Dto
{
    public class GetCustomHolidayListInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Holiday DESC";
            }
        }
    }
}
