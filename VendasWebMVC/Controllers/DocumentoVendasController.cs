using Microsoft.AspNetCore.Mvc;

namespace VendasWebMVC.Controllers
{
    public class DocumentoVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscaSimples()
        {
            return View();
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}
