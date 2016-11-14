using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Organizations;
using jrt.jcgl.Authorization.Users;
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
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        public SchedulingsAppService(ISchedulingManager _schedulingManager,
            IRepository<Scheduling, long> _schedulingRepository,
            ISchedulingsListExcelExporter _schedulingsListExcelExporter,
            IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository,
            IRepository<OrganizationUnit, long> _organizationUnitRepository)
        {
            this._schedulingManager = _schedulingManager;
            this._schedulingRepository = _schedulingRepository;
            this._schedulingsListExcelExporter = _schedulingsListExcelExporter;
            this._userOrganizationUnitRepository = _userOrganizationUnitRepository;
            this._organizationUnitRepository = _organizationUnitRepository;
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
                            orderby s.SchedulingDate
                            select new
                            {
                                s,
                                extractMemberName = s.ExtractMember.DisplayName,
                                membraneMemberName = s.MembraneMember.DisplayName
                            };

                query = query.WhereIf(input.StartDate.HasValue, q => q.s.SchedulingDate >= input.StartDate);
                query = query.WhereIf(input.EndDate.HasValue, q => q.s.SchedulingDate <= input.EndDate);

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
        public async Task<List<SchedulingDayWorkDto>> GetSchedulingInfoFormDate(GetSchedulingWorkInDateInput input)
        {
            try
            {
                List<SchedulingDayWorkDto> output = new List<SchedulingDayWorkDto>();
                if (!input.WorkDate.HasValue)
                    return output;
                var schedulings = _schedulingRepository.GetAll().WhereIf(input.WorkDate.HasValue, s => s.SchedulingDate == input.WorkDate);
                if (schedulings != null)
                {
                    var items = await schedulings.ToListAsync();
                    foreach (var work in items)
                    {
                        if (work.ExtractMemberId != null)
                        {
                            var user = await getOrganzationUsers((long)work.ExtractMemberId);
                            if (user != null && user.Count >= 3)
                                output.Add(new SchedulingDayWorkDto
                                {
                                    OrganzationName = work.ExtractMember.DisplayName,
                                    MemberOneName = user[0].Name,
                                    MemberTwoName = user[1].Name,
                                    MemberThreeName = user[2].Name,
                                    WorkType = work.WorkType,
                                    MemberType = MemberType.Extract
                                });
                        }
                        if (work.MembraneMemberId != null)
                        {
                            var user = await getOrganzationUsers((long)work.MembraneMemberId);
                            if (user != null && user.Count >= 3)
                                output.Add(new SchedulingDayWorkDto
                                {
                                    OrganzationName = work.MembraneMember.DisplayName,
                                    MemberOneName = user[0].Name,
                                    MemberTwoName = user[1].Name,
                                    MemberThreeName = user[2].Name,
                                    WorkType = work.WorkType,
                                    MemberType = MemberType.Membrane
                                });
                        }
                    }
                }
                return output;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private async Task<List<User>> getOrganzationUsers(long oid)
        {
            var query = from uou in _userOrganizationUnitRepository.GetAll()
                        join ou in _organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id
                        join user in UserManager.Users on uou.UserId equals user.Id
                        where uou.OrganizationUnitId == oid
                        select user;

            return await query.ToListAsync(); ;
        }
    }
}

