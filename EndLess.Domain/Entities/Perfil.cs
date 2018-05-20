using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndLess.Domain.Entities
{
    [Table(nameof(Perfil))]
    public class Perfil : Entity
    {
        [Column(TypeName = "varchar"),
            StringLength(50, ErrorMessage = "limite excedido"),
            Required(ErrorMessage = "campo obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
