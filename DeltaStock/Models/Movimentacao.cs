namespace DeltaStock.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int SaldoAnterior { get; set; }
        public int SaldoFinal { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string? Id_documento { get; set; }
        public string? Motivo { get; set; }

    }
}