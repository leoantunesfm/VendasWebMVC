using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Models
{
    public class DocumentoVenda
    {
        public int Id { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorTotal { get; private set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<DocumentoVendaItem> Itens { get; set; } = new List<DocumentoVendaItem>();

        public DocumentoVenda() { }

        public DocumentoVenda(int id, int numeroDocumento, DateTime dataEmissao, double valorTotal, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            Status = status;
            Vendedor = vendedor;
        }

        public void AdicionarItens(DocumentoVendaItem item)
        {
            Itens.Add(item);
        }

        public void RemoverItens(DocumentoVendaItem item)
        {
            Itens.Remove(item);
        }
        public void ProcessaVenda()
        {
            ValorTotal = Itens.Sum(item => item.SubTotal());
        }
    }
}
