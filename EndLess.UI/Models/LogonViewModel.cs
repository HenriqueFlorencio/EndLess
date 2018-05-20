using System.ComponentModel.DataAnnotations;

namespace EndLess.UI.Models
{
    public class LogonViewModel
    {
        [Required(ErrorMessage = "Email obrigatório"),
            StringLength(80, ErrorMessage = "limite excedido"),
            RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)", ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório"), StringLength(80, ErrorMessage = "limite excedido")]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}