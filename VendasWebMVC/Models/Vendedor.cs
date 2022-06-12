using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<DocumentoVenda> Vendas { get; set; } = new List<DocumentoVenda>();

        public Vendedor() { }

        public Vendedor(int id, string codigo, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Codigo = codigo;
            Nome = Nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVendas(DocumentoVenda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVendas(DocumentoVenda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime periodoInicial, DateTime periodoFinal)
        {
            return Vendas.Where(venda => venda.DataEmissao >= periodoInicial && venda.DataEmissao <= periodoFinal).Sum(venda => venda.ValorTotal);
        }
    }
}
