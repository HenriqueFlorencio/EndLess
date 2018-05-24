using System.Web.Mvc;

namespace EndLess.UI.Controllers
{
    [Authorize]
    public class CursoController : Controller
    {
        public ActionResult Index() => View();

        [HttpPost]
        public ActionResult Index(int? IdCurso, int? IdUsuario)
        {
            return RedirectToAction("Index", "Curso");
        }
    }
}