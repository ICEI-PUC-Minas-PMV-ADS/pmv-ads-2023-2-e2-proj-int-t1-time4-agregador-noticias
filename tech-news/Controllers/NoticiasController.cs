using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tech_news.Models;
using static Tech_news.Models.Noticia;

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
            var viewModel = new NoticiaFilterViewModel
            {
                Noticias = await _context.Noticias.ToListAsync(),
                TagList = new SelectList(Enum.GetValues(typeof(Tag)))
            };

            return View(viewModel);
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

        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin, User")]
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

        [HttpGet]
        public IActionResult FiltroTag(Tag? selectedTag)
        {
            var viewModel = new NoticiaFilterViewModel
            {
                TagList = new SelectList(Enum.GetValues(typeof(Tag))),
                SelectedTag = selectedTag,
            };

            if (selectedTag != null)
            {
                viewModel.Noticias = _context.Noticias.Where(n => n.Tag == selectedTag).ToList();
            }
            else
            {
                viewModel.Noticias = _context.Noticias.ToList();
                viewModel.SelectedTag = null;
            }

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult FiltroData(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);

            var NoticiasFiltradas = _context.Noticias
                .Where(n => n.DataPublicacao >= startDate && n.DataPublicacao < endDate)
                .ToList();

            var viewModel = new Noticia.NoticiaFilterViewModel
            {
                Noticias = NoticiasFiltradas,
                TagList = new SelectList(Enum.GetValues(typeof(Tag))),
                StartDate = startDate,
                EndDate = endDate
            };

            return View("Index", viewModel);
        }

        public IActionResult FiltroHoje()
        {
            DateTime today = DateTime.Today;
            return RedirectToAction("FiltroData", new { startDate = today, endDate = today });
        }

        public IActionResult FiltroOntem()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            return RedirectToAction("FiltroData", new { startDate = yesterday, endDate = yesterday });
        }

        public IActionResult Filtro7Dias()
        {
            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endDate = DateTime.Today;
            return RedirectToAction("FiltroData", new { startDate = startDate, endDate = endDate });
        }

        public IActionResult FiltroUltimoMes()
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            DateTime endDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);

            return RedirectToAction("FiltroData", new { startDate = startDate, endDate = endDate });
        }

    }

}