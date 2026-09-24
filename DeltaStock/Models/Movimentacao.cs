namespace DeltaStock.Models
{
    /// <summary>
    /// Classe Model que representa a estrutura de uma movimentação de estoque na aplicação,
    /// espelhando as colunas correspondentes da tabela no banco de dados.
    /// </summary>
    public class Movimentacao
    {
        // Identificador único da movimentação (Chave Primária id_mov)
        public int Id { get; set; }

        // Data e hora em que a movimentação foi realizada (data_mov)
        public DateTime Data { get; set; }

        // Tipo da operação: ENTRADA, SAIDA, AJUSTE+, AJUSTE-, PERDA (tipo_mov)
        public string Tipo { get; set; } = string.Empty;

        // Quantidade movimentada de itens (quantidade_mov)
        public int Quantidade { get; set; }

        // Saldo do produto antes de realizar esta movimentação (saldo_anterior_mov)
        public int SaldoAnterior { get; set; }

        // Saldo do produto resultante após a movimentação (saldo_final_mov)
        public int SaldoFinal { get; set; }

        // Origem do registro, ex: Venda, Compra, Reposição, Descarte (origem_mov)
        public string Origem { get; set; } = string.Empty;

        // Identificador do documento associado (ex: NF, Nota de Venda). O '?' indica que aceita valor NULO (id_documento_mov)
        public string? Id_documento { get; set; }

        // Motivo da movimentação (utilizado em perdas ou ajustes). O '?' indica que aceita valor NULO (motivo_mov)
        public string? Motivo { get; set; }
    }
}