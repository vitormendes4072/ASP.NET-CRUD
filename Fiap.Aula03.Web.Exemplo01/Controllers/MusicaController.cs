using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        //Enviar a lista de opções para o select
        private void CarregarAlbuns()
        {
            var lista = _context.Albuns.OrderBy(a => a.Nome).ToList();
                                  //lista, Propriedade para o value, Propriedade para o texto
            ViewBag.albuns = new SelectList(lista, "AlbumId", "Nome");
        }

        // ? -> permite atribuir null
        public IActionResult Index(string nomeBusca, Genero? generoBusca)
        {
            //Pesquisar por parte do nome
            var lista = _context.Musicas.Where(m =>
                (m.Nome.Contains(nomeBusca) || nomeBusca == null) &&
                (m.Genero == generoBusca || generoBusca == null)).Include(m => m.Album).ToList();
            //Envia a lista de musicas para a View
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarAlbuns();
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Musica musica)
        {
            TempData["msg"] = $"Música {musica.Nome} cadastrada com sucesso!";
            _context.Musicas.Add(musica); //Adiciona no context
            _context.SaveChanges(); //Commit
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remover(int id)
        {
            var musica = _context.Musicas.Find(id);
            TempData["msg"] = $"Música {musica.Nome} removida com sucesso!";
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
            TempData["msg"] = $"Música {musica.Nome} atualizada com sucesso!";
            _context.Musicas.Update(musica);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            //Pesquisa a musica pelo Id, incluindo o relacionamento com o álbum
            var musica = _context.Musicas.Include(m => m.Album).Where(m => m.MusicaId == id).FirstOrDefault();
            return View(musica);
        }
    }
}
