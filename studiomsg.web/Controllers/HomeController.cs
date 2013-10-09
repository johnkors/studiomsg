using System.Web.Mvc;

namespace studiomsg.web.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}