namespace VendasWebMVC.Models
{
    public class CategoriaProduto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
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
