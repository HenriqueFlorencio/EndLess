using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLess.Domain.Entities
{
    [Table(nameof(Curso))]
    public class Curso : Entity
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Sitacao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
