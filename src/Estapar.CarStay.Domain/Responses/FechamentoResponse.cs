namespace Estapar.CarStay.Domain.Responses
{
    public class FechamentoResponse
    {
        public int TotalVeiculos { get; set; }
        public decimal ValorTotal { get; set; }
        public IEnumerable<Detalhes> Detalhes { get; set; }
    }

    public class Detalhes
    {
        public string FormaPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public int TotalCarros { get; set; }
    }
}
