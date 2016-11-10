using Abp.AutoMapper;
using jrt.jcgl.MultiTenancy;
using jrt.jcgl.MultiTenancy.Dto;
using jrt.jcgl.Web.Areas.Mpa.Models.Common;

namespace jrt.jcgl.Web.Areas.Mpa.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}