using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services;
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Controllers
{
    public class CategoriaProdutosController : Controller
    {
        private readonly CategoriaProdutoService _categoriaProdutoService;

        public CategoriaProdutosController(CategoriaProdutoService categoriaProdutoService)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoriaProdutoService.ListarTodosAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaProduto categoriaProduto)
        {
            //if (!ModelState.IsValid)
            //{
            //    var departamentos = await _departamentoService.ListarTodosAsync();
            //    var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            //    return View(viewModel);
            //}

            await _categoriaProdutoService.InserirAsync(categoriaProduto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id não foi fornecido." });
            }

            var obj = await _categoriaProdutoService.BuscaPorIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id da categoria não encontrado." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoriaProdutoService.ExcluirAsync(id);
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

            var obj = await _categoriaProdutoService.BuscaPorIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id da categoria não encontrado." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id não foi fornecido." });
            }

            var obj = await _categoriaProdutoService.BuscaPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id da categoria não encontrado." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaProduto categoriaProduto)
        {
            //if (!ModelState.IsValid)
            //{
            //    var departamentos = await _departamentoService.ListarTodosAsync();
            //    var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            //    return View(viewModel);
            //}

            if (id != categoriaProduto.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id informado não corresponde." });
            }
            try
            {
                await _categoriaProdutoService.UpdateAsync(categoriaProduto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
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
