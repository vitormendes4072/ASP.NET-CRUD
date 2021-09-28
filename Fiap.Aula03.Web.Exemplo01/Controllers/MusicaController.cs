using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class MusicaController : Controller
    {
        //Atributo para armazenar o context
        private ProdutoraContext _context;

        //Construtor que recebe por injeção de dependência o Context
        public MusicaController(ProdutoraContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Musicas.ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Musica musica)
        {
            TempData["msg"] = $"Música {musica} cadastrada com sucesso!";
            _context.Musicas.Add(musica); //Adiciona no context
            _context.SaveChanges(); //Commit
            return RedirectToAction("Cadastrar");
        }
        [HttpPost]
        public IActionResult Remover(int id)
        {
            TempData["msg"] = "Música removida com sucesso!";
            var musica = _context.Musicas.Find(id);
            _context.Musicas.Remove(musica);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var musica = _context.Musicas.Find(id);
            return View(musica);
        }
        [HttpPost]
        public IActionResult Editar(Musica musica)
        {
            TempData["msg"] = $"Música {musica} atualizada com sucesso!";
            _context.Musicas.Update(musica);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
