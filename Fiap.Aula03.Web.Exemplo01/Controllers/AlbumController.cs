using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class AlbumController : Controller
    {
        private ProdutoraContext _context;
        public AlbumController(ProdutoraContext context)
        {
            _context = context;
        }
        public IActionResult Index(string nomeBusca)
        {
            ViewBag.lista = _context.Albuns.OrderBy(a => a.Nome).Where(a => 
                a.Nome.Contains(nomeBusca) || nomeBusca == null);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Album album)
        {
            TempData["msg"] = $"Album {album.Nome} cadastrado!";
            _context.Albuns.Add(album);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remover(int id)
        {
            var album = _context.Albuns.Find(id);
            TempData["msg"] = $"Albúm {album.Nome} removido!";
            _context.Albuns.Remove(album);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var album = _context.Albuns.Find(id);
            return View(album);
        }

        public IActionResult Editar(Album album)
        {
            _context.Albuns.Update(album);
            _context.SaveChanges();
            TempData["msg"] = $"Albúm {album.Nome} atualizado!";
            return RedirectToAction("Index");
        }
    }
}
