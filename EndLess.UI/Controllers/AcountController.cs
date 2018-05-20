using EndLess.Data.EF.Repositories;
using EndLess.Domain.Contract;
using EndLess.Domain.Helpeers;
using EndLess.UI.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Security;

namespace EndLess.UI.Controllers
{
    public class AcountController: Controller
    {
        private readonly IUsuarioRepository _usuarioRepository = new UsuarioRepository();

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
                {
                    // addmodelerror para forçar uma mensagem no model state
                    ModelState.AddModelError("Email", "Email não localizado");
                }
                else
                {
                    if (usuario.Senha != model.Senha.Encrypt())
                    {
                        ModelState.AddModelError("Email", "Senha inválida");
                    }
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
                    return RedirectToAction("Index", "Produtos");
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _usuarioRepository.Dispose();
        }
    }
}
