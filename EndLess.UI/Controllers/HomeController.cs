using EndLess.Domain.Contract;
using System.Web.Mvc;

namespace EndLess.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICursoRepository _cursoRepository;

        public HomeController(IUsuarioRepository usuarioRepository, ICursoRepository cursoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cursoRepository = cursoRepository;
        }

        public ActionResult Index(int Id)
        {
            var cursos = _usuarioRepository.Get(Id).Cursos;

            return View(cursos);
        }
    }
}