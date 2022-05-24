using Microsoft.AspNetCore.Mvc;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
