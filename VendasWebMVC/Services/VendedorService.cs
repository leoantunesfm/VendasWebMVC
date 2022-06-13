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

        public async Task<List<Vendedor>> ListarTodosAsync()
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).OrderBy(v => v.Codigo).ToListAsync();
        }

        public async Task InserirAsync(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscaPorIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task ExcluirAsync(int id)
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            bool existeId = await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id);
            if (!existeId)
            {
                throw new NotFoundException("Vendedor não encontrado!");
            }

            try
            {
                _context.Vendedor.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

    }
}
