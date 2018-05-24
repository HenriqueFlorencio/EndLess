using System.Web.Mvc;

namespace EndLess.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}