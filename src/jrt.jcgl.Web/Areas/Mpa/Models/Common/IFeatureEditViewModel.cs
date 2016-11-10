using System.Collections.Generic;
using Abp.Application.Services.Dto;
using jrt.jcgl.Editions.Dto;

namespace jrt.jcgl.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}