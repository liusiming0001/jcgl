using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using jrt.jcgl.Common.Dto;
using jrt.jcgl.Editions;
using Abp.Domain.Repositories;
using jrt.jcgl.Organizations;

namespace jrt.jcgl.Common
{
    [AbpAuthorize]
    public class CommonLookupAppService : AbpZeroTemplateAppServiceBase, ICommonLookupAppService
    {
        private readonly EditionManager _editionManager;
        private readonly IRepository<Organization, long> _organizationRepository;

        public CommonLookupAppService(EditionManager editionManager, IRepository<Organization, long> _organizationRepository)
        {
            _editionManager = editionManager;
            this._organizationRepository = _organizationRepository;
        }

        public async Task<ListResultOutput<ComboboxItemDto>> GetEditionsForCombobox()
        {
            var editions = await _editionManager.Editions.ToListAsync();
            return new ListResultOutput<ComboboxItemDto>(
                editions.Select(e => new ComboboxItemDto(e.Id.ToString(), e.DisplayName)).ToList()
                );
        }

        public async Task<PagedResultOutput<NameValueDto>> FindUsers(FindUsersInput input)
        {
            if (AbpSession.MultiTenancySide == MultiTenancySides.Host && input.TenantId.HasValue)
            {
                CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, input.TenantId.Value);
            }

            var query = UserManager.Users
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.EmailAddress.Contains(input.Filter)
                );

            var userCount = await query.CountAsync();
            var users = await query
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Surname)
                .PageBy(input)
                .ToListAsync();

            return new PagedResultOutput<NameValueDto>(
                userCount,
                users.Select(u =>
                    new NameValueDto(
                        u.Name,
                        u.Id.ToString()
                        )
                    ).ToList()
                );
        }

        public async Task<PagedResultOutput<NameValueDto>> FindSCX(FindSCXInput input)
        {
            var query = _organizationRepository.GetAll().Where(o => o.Type == OrganizationType.ProdutionLine)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                o =>
                    o.OrganizationUnit.DisplayName.Contains(input.Filter)
                );

            var items = await query
                 .OrderBy(u => u.Id)
                 .PageBy(input)
                 .ToListAsync();

            var list = from o in items
                       select new NameValueDto
                       {
                           Name = o.OrganizationUnit.DisplayName,
                           Value = o.OrganizationUnitId.ToString()
                       };

            var count = await query.CountAsync();

            return new PagedResultOutput<NameValueDto>(count, list.ToList());
        }
    }
}
