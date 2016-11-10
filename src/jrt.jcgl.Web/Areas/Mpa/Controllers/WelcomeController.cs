using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using jrt.jcgl.Web.Controllers;

namespace jrt.jcgl.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}