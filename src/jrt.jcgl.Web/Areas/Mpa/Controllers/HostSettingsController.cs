using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using jrt.jcgl.Authorization;
using jrt.jcgl.Configuration.Host;
using jrt.jcgl.Web.Controllers;

namespace jrt.jcgl.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Settings)]
    public class HostSettingsController : AbpZeroTemplateControllerBase
    {
        private readonly IHostSettingsAppService _hostSettingsAppService;

        public HostSettingsController(IHostSettingsAppService hostSettingsAppService)
        {
            _hostSettingsAppService = hostSettingsAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _hostSettingsAppService.GetAllSettings();

            return View(output);
        }
    }
}