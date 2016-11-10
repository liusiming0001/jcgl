using System.Collections.Generic;
using Abp.Application.Services.Dto;
using jrt.jcgl.Editions.Dto;

namespace jrt.jcgl.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput : IOutputDto
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}