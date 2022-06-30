using System.ComponentModel.DataAnnotations;

namespace VendasWebMVC.Models
{
    public class CategoriaProduto
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        public CategoriaProduto() { }

        public CategoriaProduto(int id, string codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }
    }
}
