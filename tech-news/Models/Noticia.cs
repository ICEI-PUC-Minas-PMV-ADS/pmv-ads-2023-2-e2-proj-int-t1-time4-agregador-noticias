using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_news.Models
{
    [Table("Noticias")]
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o título!")]
        public int Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o link!")]
        public string Link { get; set; }
    }
}
