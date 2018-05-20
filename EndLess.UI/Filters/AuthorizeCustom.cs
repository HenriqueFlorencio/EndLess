using EndLess.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EndLess.UI.Filters
{
    public class AuthorizeCustom : AuthorizeAttribute
    {
        private readonly List<string> _perfis;
        public AuthorizeCustom(string perfis)
        {
            _perfis = perfis.Split(',').ToList();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //return base.AuthorizeCore(httpContext);
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            var user = JsonConvert.DeserializeObject<UsuarioViewModel>(httpContext.User.Identity.Name);
            return _perfis.Contains(user.PerfilNome);



        }
    }
}