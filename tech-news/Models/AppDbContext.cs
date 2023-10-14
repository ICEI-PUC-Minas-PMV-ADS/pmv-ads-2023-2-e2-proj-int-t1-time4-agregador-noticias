using Microsoft.EntityFrameworkCore;

namespace Tech_news.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Noticia> Noticias { get; set; }
    }
}
