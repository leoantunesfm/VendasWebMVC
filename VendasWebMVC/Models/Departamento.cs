using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendasWebMVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento() { }

        public Departamento(int id, string codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendas(DateTime periodoInicial, DateTime periodoFinal)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(periodoInicial, periodoFinal));
        }
    }
}
