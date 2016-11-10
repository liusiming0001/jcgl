using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace IMTest.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : IMTestControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}