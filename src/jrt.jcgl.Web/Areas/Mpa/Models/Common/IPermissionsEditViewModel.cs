using System.Collections.Generic;
using jrt.jcgl.Authorization.Dto;

namespace jrt.jcgl.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}