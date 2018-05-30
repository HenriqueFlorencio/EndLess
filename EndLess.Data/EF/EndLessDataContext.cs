using EndLess.Domain.Entities;
using System.Data.Entity;

namespace EndLess.Data.EF
{
    public class EndLessDataContext: DbContext
    {
        public EndLessDataContext(): base("EndLessContext")
        {
            // usa apenas para gerção de carga para o desenvolvedor
            Database.SetInitializer(new DbInitializer());

            // Dessa forma nunca vai gerar a base
            //Database.SetInitializer<HFStoreDataContext>(null);
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        //public DbSet<UsuarioCurso> CursosUsuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>()
                .HasMany(p => p.Usuarios)
                .WithMany(p => p.Cursos)
                .Map(m => {
                    m.ToTable("CursoUsuario");
                    m.MapLeftKey("CursoId");
                    m.MapRightKey("UsuarioId");
                });
        }
    }
}
