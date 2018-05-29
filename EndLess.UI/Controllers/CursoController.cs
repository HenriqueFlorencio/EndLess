using EndLess.Domain.Contract;
using EndLess.Domain.Entities;
using System.Web.Mvc;

namespace EndLess.UI.Controllers
{
    [Authorize]
    public class CursoController : Controller
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public ActionResult Index()
        {
            return View(_cursoRepository.Get());
        }

        public ActionResult DisplayCurso()
        {
            return View();
        }
        public ActionResult AddEdit(int? id)
        {
            Curso curso = new Curso();

            if (id != null)
            {
                curso = _cursoRepository.Get(id);

                if (curso == null)
                {
                    return HttpNotFound();
                }
            }

            ViewBag.Cursos = _cursoRepository.Get();

            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEdit(Curso model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                    _cursoRepository.Add(model);
                else
                    _cursoRepository.Update(model);

                return RedirectToAction("Logon", "Acount");
            }

            return View(model);
        }

    }
}