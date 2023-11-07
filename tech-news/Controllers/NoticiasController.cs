using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
        public async Task<IActionResult> Create([Bind("Id,Titulo,Link,Tag")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                noticia.Tag = (Tag)noticia.Tag;
                int usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                noticia.UsuarioId = usuarioId;
                noticia.DataPublicacao = DateTime.Now;

                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Noticia noticia)
        {
            if (id != noticia.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingUsuario = await _context.Usuarios.FindAsync(noticia.UsuarioId);

                if (existingUsuario == null)
                {
                    int usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    noticia.UsuarioId = usuarioId;
                    ModelState.Remove("UsuarioId");
                }

                _context.Noticias.Update(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(noticia);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound(ModelState);

            var dados = await _context.Noticias
                .Include(d => d.Usuarios)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Noticias.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

    }

}