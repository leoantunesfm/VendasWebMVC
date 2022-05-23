using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Models
{
    public class DocumentoVenda
    {
        public int Id { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorTotal { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public DocumentoVenda() { }

        public DocumentoVenda(int id, int numeroDocumento, DateTime dataEmissao, double valorTotal, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            ValorTotal = valorTotal;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
