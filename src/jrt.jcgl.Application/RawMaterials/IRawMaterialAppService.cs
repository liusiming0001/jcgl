using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.RawMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.RawMaterials
{
    public interface IRawMaterialAppService : IApplicationService
    {
        Task CreateOrUpdateRawMaterial(CreateOrUpdateDto input);
        Task<CreateOrUpdateDto> GetRawMaterialForEdit(int? id);
        Task<ListResultOutput<RawMaterialListDto>> GetRawMaterialList();
        ListResultDto<NameValueDto> GetUnitsTypes();
        Task DeleteRawMaterial(int id);
        ListResultDto<NameValueDto> GetRawMaterialConstantTypes();
    }
}
