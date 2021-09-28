using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class ArtistaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
