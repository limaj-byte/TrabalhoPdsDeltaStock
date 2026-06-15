using System.ComponentModel.DataAnnotations;

namespace DeltaStock.Models;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome do produto.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o codigo.")]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o fornecedor.")]
    public string Fornecedor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a categoria.")]
    public string Categoria { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Informe um preco de compra valido.")]
    public decimal PrecoCompra { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Informe um preco de venda valido.")]
    public decimal PrecoVenda { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Informe uma quantidade valida.")]
    public int Quantidade { get; set; }
}
