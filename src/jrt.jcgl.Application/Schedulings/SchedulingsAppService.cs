using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using jrt.jcgl.Dto;
using jrt.jcgl.Organizations;
using jrt.jcgl.Schedulings.Dto;
using jrt.jcgl.Schedulings.Exporting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings
{
    public class SchedulingsAppService : AbpZeroTemplateAppServiceBase, ISchedulingsAppService
    {
        private readonly ISchedulingManager _schedulingManager;
        private readonly IRepository<Scheduling, long> _schedulingRepository;
        private readonly ISchedulingsListExcelExporter _schedulingsListExcelExporter;
        public SchedulingsAppService(ISchedulingManager _schedulingManager,
            IRepository<Scheduling, long> _schedulingRepository,
            ISchedulingsListExcelExporter _schedulingsListExcelExporter)
        {
            this._schedulingManager = _schedulingManager;
            this._schedulingRepository = _schedulingRepository;
            this._schedulingsListExcelExporter = _schedulingsListExcelExporter;
        }

        public async Task SchedulingWork(CreateSchedulingWorkDto input)
        {
            await _schedulingManager.SchedulingWork(
                input.BatchNum,
                input.ExtractWorkInfo,
                input.MembraneWorkInfo,
                input.MedicinalName,
                input.Remark,
                input.Type
                );
        }

        public async Task<PagedResultOutput<SchedulingListDto>> GetSchedulingList(GetSchedulingWorkInput input)
        {
            try
            {
                var query = from s in _schedulingRepository.GetAll()
                                //where s.SchedulingDate >= input.StartDate && s.SchedulingDate < input.EndDate
                            orderby s.SchedulingDate
                            select new
                            {
                                s,
                                extractMemberName = s.ExtractMember.DisplayName,
                                membraneMemberName = s.MembraneMember.DisplayName
                            };

                query = query.WhereIf(input.StartDate.HasValue, q => q.s.SchedulingDate >= input.StartDate);
                query = query.WhereIf(input.EndDate.HasValue, q => q.s.SchedulingDate < input.EndDate);

                var items = await query
                                .PageBy(input)
                                .ToListAsync();

                var count = await query.CountAsync();

                var list = items.Select(item =>
                        {
                            var dto = item.s.MapTo<SchedulingListDto>();
                            dto.ExtractMemberName = item.extractMemberName;
                            dto.MembraneMemberName = item.membraneMemberName;
                            return dto;
                        }
                ).ToList();


                return new PagedResultOutput<SchedulingListDto>(count, list);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public CreateSchedulingWorkDto InitCreateDto()
        {
            return new CreateSchedulingWorkDto();
        }
        public ListResultDto<NameValueDto> GetSchedulingTypes()
        {
            return EnumToNameValueList<SchedulingType>();
        }

        public async Task<FileDto> ExportToExcel(GetSchedulingWorkInput input)
        {
            var query = from s in _schedulingRepository.GetAll()
                            //where s.SchedulingDate >= input.StartDate && s.SchedulingDate < input.EndDate
                        orderby s.SchedulingDate
                        select new
                        {
                            s,
                            extractMemberName = s.ExtractMember.DisplayName,
                            membraneMemberName = s.MembraneMember.DisplayName
                        };

            query = query.WhereIf(input.StartDate.HasValue, q => q.s.SchedulingDate >= input.StartDate);
            query = query.WhereIf(input.EndDate.HasValue, q => q.s.SchedulingDate < input.EndDate);

            var items = await query
                            .PageBy(input)
                            .ToListAsync();

            var count = await query.CountAsync();

            var list = items.Select(item =>
            {
                var dto = item.s.MapTo<SchedulingListDto>();
                dto.ExtractMemberName = item.extractMemberName;
                dto.MembraneMemberName = item.membraneMemberName;
                return dto;
            }
            ).ToList();


            return _schedulingsListExcelExporter.ExportToFile(list);
        }
    }
}
