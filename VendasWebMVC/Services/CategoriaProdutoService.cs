using VendasWebMVC.Data;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Services
{
    public class CategoriaProdutoService
    {
        private readonly VendasWebMVCContext _context;

        public CategoriaProdutoService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaProduto>> ListarTodosAsync()
        {
            return await _context.CategoriaProduto.OrderBy(x => x.Codigo).ToListAsync();
        }

        public async Task InserirAsync(CategoriaProduto categoriaProduto)
        {
            _context.Add(categoriaProduto);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoriaProduto> BuscaPorIdAsync(int id)
        {
            return await _context.CategoriaProduto.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                var obj = await _context.CategoriaProduto.FindAsync(id);
                _context.CategoriaProduto.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task UpdateAsync(CategoriaProduto categoriaProduto)
        {
            bool existeId = await _context.CategoriaProduto.AnyAsync(x => x.Id == categoriaProduto.Id);
            if (!existeId)
            {
                throw new NotFoundException("Categoria não encontrada!");
            }

            try
            {
                _context.CategoriaProduto.Update(categoriaProduto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
