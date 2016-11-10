using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using jrt.jcgl.Organizations;
using jrt.jcgl.Schedulings.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings
{
    public class SchedulingsAppService : AbpZeroTemplateServiceBase, ISchedulingsAppService
    {
        private readonly ISchedulingManager _schedulingManager;
        private readonly IRepository<Scheduling, long> _schedulingRepository;

        public SchedulingsAppService(ISchedulingManager _schedulingManager, 
            IRepository<Scheduling, long> _schedulingRepository)
        {
            this._schedulingManager = _schedulingManager;
            this._schedulingRepository = _schedulingRepository;
        }

        public async Task SchedulingWork(string BatchNum)
        {
            await _schedulingManager.SchedulingWork(BatchNum);
        }

        public async Task<ListResultOutput<SchedulingListDto>> GetSchedulingList()
        {
            try
            {
                var query = from s in
                                _schedulingRepository.GetAll()
                            select new
                            {
                                s,
                                extractMemberName = s.ExtractMember.DisplayName,
                                membraneMemberName = s.MembraneMember.DisplayName
                            };

                var items = await query.ToListAsync();

                return new ListResultOutput<SchedulingListDto> (
                    items.Select(item=>
                        {
                            var dto = item.s.MapTo<SchedulingListDto>();
                            dto.ExtractMemberName=item.extractMemberName;
                            dto.MembraneMemberName=item.membraneMemberName;
                            return dto;
                        }
                        ).ToList()
                );
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
