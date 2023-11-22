using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tech_news.Models;
using Tech_news.Authorization;
using Microsoft.AspNetCore.Identity;


namespace Tech_news.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        public UsuariosController(AppDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            //a propriedade _context, recebe o context da aplicação(injeção de dependência). Toda vez q precisar inserir/alterar um item, usaremos a variável context
            _authorizationService = authorizationService;

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index() //a função index lista os usuários cadastrados
        {
            var dados = await _context.Usuarios.ToListAsync(); //o 'task' e o 'await/async' tornam essa função assíncrona
            return View(dados);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuarios usuarios)
        {
            var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuarios.Email);

            if (dados == null)
            {
                ViewBag.Message = "Verifique os dados de usuário e/ou senha!";
                return View();
            }

            bool isSenhaOk = BCrypt.Net.BCrypt.Verify(usuarios.Senha, dados.Senha);

            if (isSenhaOk)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.Email, dados.Email),
                    new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                    new Claim(ClaimTypes.Role, dados.Perfil.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha invalidos!";
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Usuarios");
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                // Se for Admin, libera a escolha do Perfil
                ViewData["AllowRoleSelection"] = true;
            }
            else
            {
                // Se não for Admin, se for User a seleção de usuário será desativada
                ViewData["AllowRoleSelection"] = false;
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    // Se for Admin, libera a escolha do Perfil
                    _context.Usuarios.Add(usuarios);
                }
                else
                {
                    // Se não for Admin, se for User a seleção de usuário será desativada
                    usuarios.Perfil = Perfil.User;
                    _context.Usuarios.Add(usuarios);
                }

                usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null )
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Usuarios usuarios)
        {
            
            if (ModelState.IsValid)
            {
                usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                _context.Usuarios.Update(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Usuarios.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin")]
        [Route("/usuarios/buscar")]
        public async Task<IActionResult> Index(string search)
        {
            var users = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(u => u.Nome.Contains(search) || u.Email.Contains(search));
            }

            return View(await users.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Usuarios.FindAsync(int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            return View("EditProfile", user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(Usuarios usuarios)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var currentUserId))
            {
                return Forbid(); // Retornar um código 403 se o usuário não estiver autorizado
            }

            if (currentUserId != usuarios.Id)
            {
                return Forbid(); // Retornar um código 403 se o usuário não estiver autorizado
            }

            if (ModelState.IsValid)
            {
                // Carregue o usuário do banco de dados
                var userFromDb = await _context.Usuarios.FindAsync(usuarios.Id);

                if (userFromDb == null)
                {
                    return NotFound();
                }

                // Atualize apenas os campos permitidos
                userFromDb.Nome = usuarios.Nome;
                userFromDb.Email = usuarios.Email;
                userFromDb.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);

                // Salve as alterações
                await _context.SaveChangesAsync();

                var updatedUser = await _context.Usuarios.FindAsync(currentUserId);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, updatedUser.Nome),
                    new Claim(ClaimTypes.Email, updatedUser.Email),
                    new Claim(ClaimTypes.NameIdentifier, updatedUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, updatedUser.Perfil.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                await HttpContext.SignInAsync(principal); // Reautenticar o usuário


                return RedirectToAction("Index", "Noticias");
            }

            return View();
        }



        private bool IsUserAuthorized(int userId)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userIdClaim != null && int.TryParse(userIdClaim, out var currentUserId) && currentUserId == userId;
        }
    }

}