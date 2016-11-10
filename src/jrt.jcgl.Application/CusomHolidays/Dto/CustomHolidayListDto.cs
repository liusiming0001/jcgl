using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using jrt.jcgl.CustomHolidays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.CusomHolidays.Dto
{
    [AutoMapFrom(typeof(CustomHoliday))]
    public class CustomHolidayListDto:EntityDto<long>
    {
        public DateTime Holiday { get; set; }
    }
}
