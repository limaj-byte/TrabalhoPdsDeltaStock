using DeltaStock.Models;

namespace DeltaStock.Services;

public class ProdutoLocalStore
{
    private readonly List<Produto> produtos =
    [
        new()
        {
            Id = 1,
            Nome = "Camiseta Sport Dry-Fit",
            Codigo = "CAM-001",
            Fornecedor = "Delta Fornecedores",
            Categoria = "Roupas",
            PrecoCompra = 45.00m,
            PrecoVenda = 89.90m,
            Quantidade = 520
        },
        new()
        {
            Id = 2,
            Nome = "Fone Sony WH-1000XM5",
            Codigo = "FON-002",
            Fornecedor = "Sony Brasil",
            Categoria = "Eletronicos",
            PrecoCompra = 1300.00m,
            PrecoVenda = 1869.00m,
            Quantidade = 350
        }
    ];

    private int proximoId = 3;

    public IReadOnlyList<Produto> ObterTodos()
    {
        return produtos;
    }

    public void Adicionar(Produto produto)
    {
        produto.Id = proximoId++;
        produtos.Add(produto);
    }

    public void Remover(int id)
    {
        Produto? produto = produtos.FirstOrDefault(item => item.Id == id);

        if (produto is not null)
        {
            produtos.Remove(produto);
        }
    }
}
