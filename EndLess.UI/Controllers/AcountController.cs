using EndLess.Data.EF.Repositories;
using EndLess.Domain.Contract;
using EndLess.Domain.Entities;
using EndLess.Domain.Helpeers;
using EndLess.UI.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Security;

namespace EndLess.UI.Controllers
{
    public class AcountController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;
        private IUsuarioRepository _usuarioRepository;

        private IUsuarioRepository _usuarioRepository2;

        public AcountController(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository, IUsuarioRepository usuarioRepository2)
        {
            _perfilRepository = perfilRepository;
            _usuarioRepository = usuarioRepository;
            _usuarioRepository2 = usuarioRepository2;
        }

        [HttpGet]
        public ActionResult Logon(string returnUrl)
        {
            return View(new LogonViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[RequireHttps]
        public ActionResult Logon(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                // essa é uma forma de usar com LINQ Fluent
                var usuario = _usuarioRepository.GetByEmail(model.Email);

                if (usuario == null)
                    // addmodelerror para forçar uma mensagem no model state
                    ModelState.AddModelError("Email", "Email não localizado");
                else
                {
                    if (usuario.Senha != model.Senha.Encrypt())
                        ModelState.AddModelError("Senha", "Senha inválida");
                }

                if (usuario.Email.Equals(model.Email) && usuario.Senha.Equals(model.Senha.Encrypt()))
                {

                    var usuarioViewModel = new UsuarioViewModel()
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        PerfilId = usuario.PerfilId,
                        PerfilNome = usuario.Perfil.Nome
                    };

                    var json = JsonConvert.SerializeObject(usuarioViewModel);
                    FormsAuthentication.SetAuthCookie(json, false);

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && (Url.IsLocalUrl(model.ReturnUrl)))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logon");
        }

        //[Route("Produtos/Edit/{id}")]
        //[Route("Produtos/Adicionar")]
        public ActionResult AddEdit(int? id)
        {
            Usuario usuario = new Usuario();

            if (id != null)
            {
                usuario = _usuarioRepository.Get(id);

                if (usuario == null)
                {
                    return HttpNotFound();
                }
            }

            ViewBag.Perfis = _perfilRepository.Get();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEdit(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _usuarioRepository2.Get(model.Id);

                if (model.Senha != usuario.Senha)
                    model.Senha = model.Senha.Encrypt();

                if (model.Id == 0)
                    _usuarioRepository.Add(model);
                else
                    _usuarioRepository.Update(model);

                FormsAuthentication.SignOut();
                return RedirectToAction("Logon", "Acount");
            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _usuarioRepository.Dispose();
        }
    }
}
