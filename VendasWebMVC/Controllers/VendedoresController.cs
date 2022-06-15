using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services;
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vendedorService.ListarTodosAsync());
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.ListarTodosAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            //if (!ModelState.IsValid)
            //{
            //    var departamentos = await _departamentoService.ListarTodosAsync();
            //    var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            //    return View(viewModel);
            //}

            await _vendedorService.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
            }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id não foi fornecido." });
            }

            var obj = await _vendedorService.BuscaPorIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do vendedor não encontrado." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vendedorService.ExcluirAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id não foi fornecido." });
            }

            var obj = await _vendedorService.BuscaPorIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do vendedor não encontrado." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id não foi fornecido." });
            }

            var obj = await _vendedorService.BuscaPorIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do vendedor não encontrado." });
            }

            List<Departamento> departamentos = await _departamentoService.ListarTodosAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            //if (!ModelState.IsValid)
            //{
            //    var departamentos = await _departamentoService.ListarTodosAsync();
            //    var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            //    return View(viewModel);
            //}

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id informado não corresponde." });
            }
            try
            {
                await _vendedorService.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
