using EndLess.Domain.Contract;
using System.Web.Mvc;

namespace EndLess.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
            _usuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = _usuarioRepository.Get();

            return View(model);
        }

    }
}