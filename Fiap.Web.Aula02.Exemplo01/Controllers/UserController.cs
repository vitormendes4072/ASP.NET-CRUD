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
            ViewData["nome"] = user.Nome;
            ViewBag.data = user.DataNascimento;

            return View(user);//Forward
            //return RedirectToAction("Cadastrar");//Redirect
            //return Content($"Nome: {user.Nome}\nData de Nascimento: {user.DataNascimento}\nE-mail: {user.Email}");
        }
    }
}
