using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Models;

namespace VendasWebMVC.Data
{
    public class VendasWebMVCContext : DbContext
    {
        public VendasWebMVCContext (DbContextOptions<VendasWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento>? Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<DocumentoVenda> DocumentoVenda { get; set; }
        public DbSet<DocumentoVendaItem> DocumentoVendaItem { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
    }
}
