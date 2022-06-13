using VendasWebMVC.Models;
using System.Linq;
using VendasWebMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _context;

        public DepartamentoService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> ListarTodosAsync()
        {
            return await _context.Departamento.OrderBy(d => d.Nome).ToListAsync();
        }
    }
}
