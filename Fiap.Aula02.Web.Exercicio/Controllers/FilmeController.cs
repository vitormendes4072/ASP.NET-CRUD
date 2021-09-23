using Fiap.Aula02.Web.Exercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exercicio.Controllers
{
    public class FilmeController : Controller
    {
        private static int _index = 0;
        private static List<Filme> _filmes = new List<Filme>();

        private void CarregarDados()
        {
            ViewBag.produtoras = new SelectList(new List<string>(new string[] { "Globo", "Paramount", "Disney", "Fox"}));
        }

        public IActionResult Index()
        {
            return View(_filmes);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarDados();
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Filme filme)
        {
            filme.Codigo = ++_index;
            _filmes.Add(filme);
            TempData["msg"] = "Filme cadastrado";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Editar(int codigo)
        {
            CarregarDados();
            var filme = _filmes.Find(filme => filme.Codigo == codigo);
            return View(filme);
        }

        [HttpPost]
        public IActionResult Editar(Filme filme)
        {
            _filmes[_filmes.FindIndex(i => i.Codigo == filme.Codigo)] = filme;
            TempData["msg"] = "Filme atualizado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int codigo)
        {
            _filmes.RemoveAll(i => i.Codigo == codigo);
            TempData["msg"] = "Filme removido!";
            return RedirectToAction("Index");
        }
    }
}
