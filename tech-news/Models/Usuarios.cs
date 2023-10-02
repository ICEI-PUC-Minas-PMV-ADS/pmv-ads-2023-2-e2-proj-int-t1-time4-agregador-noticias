using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_news.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Obrigatório informar o nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar e-mail!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        public string Senha { get; set; }
    }
}
