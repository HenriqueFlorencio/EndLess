using EndLess.Domain.Contract;
using EndLess.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EndLess.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public void Add(Usuario entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Usuario entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Usuario> Get()
        {
            throw new System.NotImplementedException();
        }

        public Usuario Get(object id)
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetByEmail(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Update(Usuario entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
