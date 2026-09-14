using System.ComponentModel.DataAnnotations;

namespace DeltaStock.Models;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o código do produto.")]
    [StringLength(100)]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o nome do produto.")]
    [StringLength(300)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(500)]
    public string Descricao { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
    public int Quantidade { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "O custo não pode ser negativo.")]
    public decimal Custo { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "O preço de venda não pode ser negativo.")]
    public decimal ValorVenda { get; set; }

    [Required(ErrorMessage = "Selecione uma categoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecione uma categoria.")]
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "Informe o status.")]
    public string Status { get; set; } = "Ativo";

    public DateTime DataCadastro { get; set; } = DateTime.Today;

    // Campos de apresentação e aliases mantidos para as telas já existentes.
    public string Categoria { get; set; } = string.Empty;
    public string Fornecedor { get; set; } = string.Empty;
    public decimal PrecoCompra { get => Custo; set => Custo = value; }
    public decimal PrecoVenda { get => ValorVenda; set => ValorVenda = value; }
}
