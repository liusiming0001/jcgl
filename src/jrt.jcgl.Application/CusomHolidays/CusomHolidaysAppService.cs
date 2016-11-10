using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using jrt.jcgl.CusomHolidays.Dto;
using jrt.jcgl.CustomHolidays;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.CusomHolidays
{
    public class CusomHolidaysAppService:AbpZeroTemplateAppServiceBase,ICusomHolidaysAppService
    {
        private readonly IRepository<CustomHoliday, long> _cusomHolidayRepository;

        public CusomHolidaysAppService(IRepository<CustomHoliday, long> _cusomHolidayRepository)
        {
            this._cusomHolidayRepository = _cusomHolidayRepository;
        }

        public async Task<PagedResultOutput<CustomHolidayListDto>> GetCusomHolidayList(GetCustomHolidayListInput input)
        {
            try
            {
                var query = _cusomHolidayRepository.GetAll();

                var count = await query.CountAsync();

                var items = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

                return new PagedResultOutput<CustomHolidayListDto>(count, items.MapTo<List<CustomHolidayListDto>>());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateCustomHoliday(DateTime holiday)
        {
            try
            {
               await _cusomHolidayRepository.InsertAsync(new CustomHoliday { Holiday=holiday});
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteCustomHoliday(long id)
        {
            try
            {
                await _cusomHolidayRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
