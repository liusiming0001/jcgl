using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.Editions.Dto;

namespace jrt.jcgl.Editions
{
    public interface IEditionAppService : IApplicationService
    {
        Task<ListResultOutput<EditionListDto>> GetEditions();

        Task<GetEditionForEditOutput> GetEditionForEdit(NullableIdInput input);

        Task CreateOrUpdateEdition(CreateOrUpdateEditionDto input);

        Task DeleteEdition(EntityRequestInput input);
    }
}