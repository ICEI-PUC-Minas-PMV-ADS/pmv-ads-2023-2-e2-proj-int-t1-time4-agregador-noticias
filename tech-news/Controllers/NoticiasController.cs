using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tech_news.Models;

namespace Tech_news.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly AppDbContext _context;
        public NoticiasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Noticias.ToListAsync();
            return View(dados);
        }
    }
}
