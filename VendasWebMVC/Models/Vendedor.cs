using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "O campo {0} dever ter entre {2} e {1} caracteres. ")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.0,50000.0,ErrorMessage = "O valor do salário é inválido.")]
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
