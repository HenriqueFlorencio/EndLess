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

                return RedirectToAction("Index", "Curso");
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var success = false;
            var msg = "produtdo nao excluído";
            var curso = _cursoRepository.Get(id);

            if (curso != null)
            {
                _cursoRepository.Delete(curso);

                success = true;
                msg = "Excluído com sucesso";
            }

            return Json(new { success, msg });
        }
        // boa pratica é sobrescrever o dispose da Classe Controller
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);

            _cursoRepository.Dispose();
            _cursoRepository.Dispose();
        }

    }
}