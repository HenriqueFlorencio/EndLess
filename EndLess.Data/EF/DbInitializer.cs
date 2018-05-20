using EndLess.Domain.Entities;
using EndLess.Domain.Helpeers;
using System.Data.Entity;

namespace EndLess.Data.EF
{
    public class DbInitializer: CreateDatabaseIfNotExists<EndLessDataContext>
    {
        protected override void Seed(EndLessDataContext context)
        {
            //base.Seed(context);
            context.Usuarios.Add(new Usuario() { Perfil = new Perfil() { Nome = "Admin" }, Nome = "Henrique Florencio", Senha = "julia2008".Encrypt(), Email = "henrique.florencio@gmail.com" });

            context.SaveChanges();
        }
    }
}
