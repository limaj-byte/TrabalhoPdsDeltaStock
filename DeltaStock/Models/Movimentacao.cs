using System.ComponentModel.DataAnnotations;

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
        public DateTime Data { get; set; } = DateTime.Now;

        // Tipo da operação: ENTRADA, SAIDA, AJUSTE+, AJUSTE-, PERDA (tipo_mov)
        [Required(ErrorMessage = "O tipo da movimentação é obrigatório.")]
        public string Tipo { get; set; } = string.Empty;

        // Quantidade movimentada de itens (quantidade_mov)
        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        // Saldo do produto antes de realizar esta movimentação (saldo_anterior_mov)
        [Required(ErrorMessage = "O saldo anterior é obrigatório.")]
        public int SaldoAnterior { get; set; }

        // Saldo do produto resultante após a movimentação (saldo_final_mov)
        [Required(ErrorMessage = "O saldo final é obrigatório.")]
        public int SaldoFinal { get; set; }

        // Origem do registro, ex: Venda, Compra, Reposição, Descarte (origem_mov)
        [Required(ErrorMessage = "A origem é obrigatória.")]
        [StringLength(50, ErrorMessage = "A origem deve ter no máximo 50 caracteres.")]
        public string Origem { get; set; } = string.Empty;

        // Identificador do documento associado (ex: NF, Nota de Venda)
        public string? Id_documento { get; set; }

        // Motivo da movimentação (utilizado em perdas ou ajustes)
        public string? Motivo { get; set; }
    }
}