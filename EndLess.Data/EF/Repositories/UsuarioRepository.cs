using EndLess.Domain.Contract;
using EndLess.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EndLess.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public Usuario GetByEmail(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
