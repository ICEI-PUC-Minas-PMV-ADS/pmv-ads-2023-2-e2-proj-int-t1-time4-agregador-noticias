using Tech_news.Models;

namespace Tech_news.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if(!context.Usuarios.Any())
                {
                    context.Usuarios.AddRange(new List<Usuarios>()
                    {
                        new Usuarios()
                        {
                            //Id = 1,
                            Nome = "Admin",
                            Email = "admin@test.com",
                            Senha = BCrypt.Net.BCrypt.HashPassword("123456"),
                            Perfil = Perfil.Admin
                        },
                        new Usuarios()
                        {
                            //Id = 2,
                            Nome = "User",
                            Email = "user@test.com",
                            Senha = BCrypt.Net.BCrypt.HashPassword("123456"),
                            Perfil = Perfil.User
                        },
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
