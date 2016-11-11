using Abp.Application.Services;
using Abp.Application.Services.Dto;
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
        Task SchedulingWork(string BatchNum, int type);

        Task<ListResultOutput<SchedulingListDto>> GetSchedulingList();
    }
}
