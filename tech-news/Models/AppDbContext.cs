using Microsoft.EntityFrameworkCore;

namespace Tech_news.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasMany( u => u.Noticias)
                .WithOne( n => n.Usuarios)
                .HasForeignKey( n => n.UsuarioId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
