using EndLess.Domain.Entities;

namespace EndLess.Domain.Contract
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByEmail(string email);
    }
}
