using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasWebMVC.Models;

namespace VendasWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> departamentos = new List<Departamento>();
            departamentos.Add(new Departamento { Codigo = 1, Nome = "ELETRÔNICOS" });
            departamentos.Add(new Departamento { Codigo = 2, Nome = "FERRAMENTAS" });

            return View(departamentos);
        }
    }
}
