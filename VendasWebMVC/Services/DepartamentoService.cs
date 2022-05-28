using VendasWebMVC.Models;
using System.Linq;
using VendasWebMVC.Data;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _context;

        public DepartamentoService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public List<Departamento> ListarTodos()
        {
            return _context.Departamento.OrderBy(d => d.Nome).ToList();
        }
    }
}
