using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class ArtistaController : Controller
    {
        private ProdutoraContext _context;
        public ArtistaController(ProdutoraContext context)
        {
            _context = context;
        }

        public IActionResult Index(string nomeBusca, GeneroArtista? generoBusca)
        {
            var lista = _context.Artistas.Include(a => a.Endereco).Where(a =>
                (a.Nome.Contains(nomeBusca) || nomeBusca == null) &&
                (a.Genero == generoBusca || generoBusca == null)).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Artista artista)
        {
            TempData["msg"] = $"Artista {artista.Nome} cadastrado!";
            _context.Artistas.Add(artista);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remover(int id)
        {
            var artista = _context.Artistas.Find(id);
            TempData["msg"] = $"Artista {artista.Nome} removido!";
            _context.Artistas.Remove(artista);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var artista = _context.Artistas.Find(id);
            return View(artista);
        }

        [HttpPost]
        public IActionResult Editar(Artista artista)
        {
            TempData["msg"] = $"Artista { artista.Nome } atualizado!";
            _context.Artistas.Update(artista);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
