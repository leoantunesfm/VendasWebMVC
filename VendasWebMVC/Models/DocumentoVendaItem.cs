namespace VendasWebMVC.Models
{
    public class DocumentoVendaItem
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public DocumentoVendaItem() { }
        public DocumentoVendaItem(int id, Produto produto, int quantidade)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
        }

        public double SubTotal()
        {
            return Quantidade * Produto.VlPreco;
        }
    }
}
