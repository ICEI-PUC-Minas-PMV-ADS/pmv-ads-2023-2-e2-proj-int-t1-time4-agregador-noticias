using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tech_news.Models;

namespace Tech_news.Controllers
{
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

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Usuarios usuarios)
        {
            if (ModelState.IsValid) //se os campos obrigatórios estiverem tds preenchidos
            {
                usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                _context.Usuarios.Add(usuarios); //adiciona usuário ao bd
                await _context.SaveChangesAsync(); //salva as alterações 
                return RedirectToAction("Index"); //retorna ao index
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
