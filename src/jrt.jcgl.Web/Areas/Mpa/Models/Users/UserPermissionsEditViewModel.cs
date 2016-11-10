using Abp.AutoMapper;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.Authorization.Users.Dto;
using jrt.jcgl.Web.Areas.Mpa.Models.Common;

namespace jrt.jcgl.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}