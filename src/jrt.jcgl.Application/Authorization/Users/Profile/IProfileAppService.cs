using System.Threading.Tasks;
using Abp.Application.Services;
using jrt.jcgl.Authorization.Users.Profile.Dto;

namespace jrt.jcgl.Authorization.Users.Profile
{
    public interface IProfileAppService : IApplicationService
    {
        Task<CurrentUserProfileEditDto> GetCurrentUserProfileForEdit();

        Task UpdateCurrentUserProfile(CurrentUserProfileEditDto input);
        
        Task ChangePassword(ChangePasswordInput input);
    }
}
