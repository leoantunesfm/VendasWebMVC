using VendasWebMVC.Data;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Services
{
    public class VendedorService
    {
        private readonly VendasWebMVCContext _context;

        public VendedorService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> ListarTodos()
        {
            return _context.Vendedor.Include(obj => obj.Departamento).OrderBy(v => v.Codigo).ToList();
        }

        public void Inserir(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor BuscaPorId(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(v => v.Id == id);
        }

        public void Excluir(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor vendedor)
        {
            if(!_context.Vendedor.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("Vendedor não encontrado!");
            }

            try
            {
                _context.Vendedor.Update(vendedor);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

    }
}
