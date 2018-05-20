using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndLess.Domain.Entities
{
    [Table(nameof(Usuario))]
    public class Usuario : Entity
    {
        [Column(TypeName = "varchar"), Required, StringLength(80)]
        public string Nome { get; set; }

        [Column(TypeName = "varchar"), Required, StringLength(80)]
        public string Email { get; set; }

        [Column(TypeName = "varchar"), Required, StringLength(50)]
        public string Senha { get; set; }

        [Column(TypeName = "datetime"), Required]
        public DateTime DataCatastro { get; set; }

        [Column(TypeName = "datetime"), Required]
        public DateTime DataAtivacao { get; set; }

        public int PerfilId { get; set; }

        [ForeignKey(nameof(PerfilId))]
        public virtual Perfil Perfil { get; set; }
    }
}
