namespace VendasWebMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public double VlPreco { get; set; }
        public CategoriaProduto Categoria { get; set; }

        public Produto() { }

        public Produto(int id, string codigo, string nome, double vlPreco, CategoriaProduto categoria)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            VlPreco = vlPreco;
            Categoria = categoria;
        }
    }
}
