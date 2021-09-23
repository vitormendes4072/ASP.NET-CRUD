using Fiap.Web.Aula02.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.Controllers
{
    public class PlanetaController : Controller
    {
        private static List<Planeta> _banco = new List<Planeta>();
        private static int _index = 0;
        private void CarregarDados()
        {
            //Envia as opções do select da galaxias
            var lista = new List<string>(new string[] { "Via Láctea", "Andrômeda", "Olho Negro", "Charuto", "Cometa" });
            //Select
            ViewBag.galaxias = new SelectList(lista);

            //Radio
            ViewBag.atmosferas = new List<string>(new string[] { "Co2, N2", "N2, O2", "H2, HE, Ch4" });
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarDados();
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Planeta planeta)
        {
            //Adicionar o planeta na lista de planetas
            planeta.Id = ++_index;
            _banco.Add(planeta);
            ViewBag.banco = _banco;
            TempData["msg"] = "Planeta cadastrado!";
            //Enviar uma mensagem de sucesso para a View
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Listar()
        {
            //ViewBag.banco = _banco;
            return View(_banco);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarDados();
            //Pesquisar o planeta pelo Id
            var planeta =_banco.Find(planeta => planeta.Id == id);

            //Enviar o planeta para a View
            return View(planeta);
        }

        [HttpPost]
        public IActionResult Editar(Planeta planeta)
        {
            //Atualizar o planeta na lista, pesquisa a posição de um elemento da lista
            _banco[_banco.FindIndex(item => item.Id == planeta.Id)] = planeta;
            

            //Mensagem de sucesso
            TempData["msg"] = "Planeta atualizado!";

            //Redirecionar para a página de listagem
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Remover o planeta da lista
            _banco.RemoveAll(planeta => planeta.Id == id);
            
            //Mensagem de sucesso
            TempData["msg"] = "Planeta removido!";

            //Redirect para a listagem
            return RedirectToAction("Listar");
        }
    }
}
