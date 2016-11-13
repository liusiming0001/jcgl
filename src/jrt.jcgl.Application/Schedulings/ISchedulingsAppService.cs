using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.Dto;
using jrt.jcgl.Schedulings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings
{
    public interface ISchedulingsAppService : IApplicationService
    {
        Task SchedulingWork(CreateSchedulingWorkDto input);

        Task<PagedResultOutput<SchedulingListDto>> GetSchedulingList(GetSchedulingWorkInput input);

        CreateSchedulingWorkDto InitCreateDto();

        ListResultDto<NameValueDto> GetSchedulingTypes();

        Task<FileDto> ExportToExcel(GetSchedulingWorkInput input);
    }
}
