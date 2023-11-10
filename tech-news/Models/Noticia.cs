using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o link!")]
        public string Link { get; set; }

        public int UsuarioId { get; set; }

        [Display(Name = "Data da Publicação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPublicacao { get; set; }

        public Usuarios Usuarios { get; set; }

        [Required(ErrorMessage = "Obrigatório selecionar a Tag da notícia!")]
        public Tag Tag { get; set; }

        public class NoticiaFilterViewModel
        {
            public IEnumerable<Noticia> Noticias { get; set; }
            public Tag? SelectedTag { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public IEnumerable<SelectListItem> TagList { get; set; }
        }
    }
    public enum Tag
    {
        IA,
        Hardware,
        Software,
        Games,
        Outros
    }
}
