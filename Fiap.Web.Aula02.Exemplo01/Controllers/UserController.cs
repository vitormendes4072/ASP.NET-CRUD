using Fiap.Web.Aula02.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.Controllers
{
    public class UserController : Controller
    {
        private static int _index = 0;
        private static List<User> _users = new List<User>();
        //URL: localhost:4565/user/cadastrar
        [HttpGet]//Abrir a página com o formulário de cadastro
        public IActionResult Cadastrar()
        {
            return View();
        }

        //URL: localhost:234564/user/cadastrar
        [HttpPost]
        public IActionResult Cadastrar(User user)
        {
            TempData["msg"] = $"Usuário {user.Nome} cadastrado com sucesso!!";
            user.Id = ++_index;
            _users.Add(user);
            return View(user);//Forward
            //return RedirectToAction("Cadastrar");//Redirect
            //return Content($"Nome: {user.Nome}\nData de Nascimento: {user.DataNascimento}\nE-mail: {user.Email}");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_users);
        }

        [HttpPost]
        public IActionResult Remover(User user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            TempData["msg"] = $"Usuário {user.Nome} removido";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var user = _users.Find(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Editar(User user)
        {
            _users[_users.FindIndex(u => u.Id == user.Id)] = user;
            TempData["msg"] = $"Usuário {user.Nome} atualizado";
            return RedirectToAction("index");
        }
    }
}
