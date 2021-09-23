using Fiap.Web.Aula02.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.Controllers
{

    public class ClienteController : Controller
    {
        private static int _index = 0;
        private static List<Cliente> _clientes = new List<Cliente>();
        //URL: /Cliente/Index ou /Cliente
        public IActionResult Index()
        {
            return View(_clientes);
        }

        //URL: /Cliente/Cadastrar
        //Criar uma Action Cadastrar que retorna uma página
        //A página terá um formulario HTML com os campos nome, cpf e botao
        
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Action que "cadastra no banco de dados"
        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            cliente.Id = ++_index;
            _clientes.Add(cliente);
            TempData["msg"] = $"Cliente {cliente.Nome} cadastrado";//Mantém as informações após um rediret
            //As informações são perdidas após um redirect:
            //ViewData["msg"] = "Cliente cadastrado 2!";
            //ViewData["nome"] = cliente.Nome; //Envia o nome do cliente para a View
            //ViewBag.cpf = cliente.Cpf;
            //ViewBag.cliente = cliente;

            //Envia o objeto cliente para a view
            return RedirectToAction("Cadastrar"); //Forward;

            //return RedirectToAction("Cadastrar"); //Redirect (Nome do método (Action))
            //return Content($"Nome: {cliente.Nome}, CPF: {cliente.Cpf}");//Retorna um texto no browser
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _clientes[_clientes.FindIndex(c => c.Id == cliente.Id)] = cliente;
            TempData["msg"] = "Cliente editado";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _clientes.RemoveAll(c => c.Id == id);
            TempData["msg"] = "Cliente removido";
            return RedirectToAction("Index");
        }
    }
}
