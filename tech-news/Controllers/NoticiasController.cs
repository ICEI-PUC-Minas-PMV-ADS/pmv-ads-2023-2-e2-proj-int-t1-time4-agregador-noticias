using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Link")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }
    }
}
