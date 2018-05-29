using EndLess.Domain.Entities;
using EndLess.Domain.Helpeers;
using System;
using System.Data.Entity;

namespace EndLess.Data.EF
{
    public class DbInitializer: CreateDatabaseIfNotExists<EndLessDataContext>
    {
        protected override void Seed(EndLessDataContext context)
        {
            //base.Seed(context);

            context.Usuarios.Add(new Usuario() {
                Perfil = new Perfil() { Nome = "Admin" },
                Nome = "Henrique Florencio",
                Senha = "julia2008".Encrypt(),
                Email = "henrique.florencio@gmail.com",
                DataCatastro = DateTime.Now,
                DataAtivacao = DateTime.Now
            });

            context.Cursos.Add(new Curso()
            {
                Titulo="Karatê-Do, Trabalhando a respiração",
                Descricao="Curso destinado a práitca de respiração, a importancia da respiração na aplicação de um golpe.",
                Sitacao= true
            });

            context.SaveChanges();
        }
    }
}
