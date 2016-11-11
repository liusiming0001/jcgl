using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.CusomHolidays.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.CusomHolidays
{
    public interface ICustomHolidaysAppService: IApplicationService
    {
        Task<PagedResultOutput<CustomHolidayListDto>> GetCusomHolidayList(GetCustomHolidayListInput input);

        Task CreateCustomHoliday(DateTime holiday);

        Task DeleteCustomHoliday(long id);

        Task<CreateCustomHolidayDto> CreateInit();
    }
}
