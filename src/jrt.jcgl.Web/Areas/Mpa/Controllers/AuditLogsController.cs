using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using jrt.jcgl.Authorization;
using jrt.jcgl.Web.Controllers;

namespace jrt.jcgl.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}