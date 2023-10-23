using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tech_news.Models;

namespace Tech_news.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context; 
            //a propriedade _context, recebe o context da aplicação(injeção de dependência). Toda vez q precisar inserir/alterar um item, usaremos a variável context
        }
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

            if(dados == null)
            {
                ViewBag.Message = "Erro aqui!";
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
            // Check if the current user is in the "Admin" role
            if (User.IsInRole("Admin"))
            {
                // If the user is an admin, allow them to choose the role
                ViewData["AllowRoleSelection"] = true;
            }
            else
            {
                // If the user is not an admin, set the role to "User" and disable role selection
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
                // Check if the current user is in the "Admin" role
                if (User.IsInRole("Admin"))
                {
                    // If the user is an admin, allow them to choose the role
                    _context.Usuarios.Add(usuarios);
                }
                else
                {
                    // If the user is not an admin, set the role to "User" and disable role selection
                    usuarios.Perfil = Perfil.User;
                    _context.Usuarios.Add(usuarios);
                }

                usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        public async Task<ActionResult> Edit(int? id) //int? é uma abreviação para Nullable<int>. Isso significa que você pode passar um valor inteiro quando chama o método Edit, ou null
        {
            if (id == null) 
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuarios usuarios)
        {
            if (id!= usuarios.Id)
                return NotFound();

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
        public async Task<ActionResult> Delete(int? id) //a base é igual ao do Details, a diferença é q ao exibir os dados na tela, ele dá a opção de apagá-los
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
    }
}
