using DeltaStock.Configs;
using DeltaStock.Models;

namespace DeltaStock.DAO;

public class ProdutoDAO
{
    private readonly Conexao _conexao;

    public ProdutoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Produto> Listar()
    {
        var produtos = new List<Produto>();

        using var conexao = _conexao.GetConnection();
        using var comando = conexao.CreateCommand();
        comando.CommandText = """
            SELECT p.id_prod, p.codigo_prod, p.nome_prod, p.descricao_prod,
                   p.quantidade_prod, p.custo_prod, p.valor_venda_prod,
                   p.status_prod, p.data_cadastro_prod, p.id_cat_fk,
                   c.nome_cat AS nome_categoria
            FROM Produto p
            INNER JOIN Categoria c ON c.id_cat = p.id_cat_fk
            ORDER BY p.nome_prod;
            """;

        using var leitor = comando.ExecuteReader();
        while (leitor.Read())
        {
            produtos.Add(new Produto
            {
                Id = leitor.GetInt32("id_prod"),
                Codigo = leitor.GetString("codigo_prod"),
                Nome = leitor.GetString("nome_prod"),
                Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_prod")) ? string.Empty : leitor.GetString("descricao_prod"),
                Quantidade = leitor.GetInt32("quantidade_prod"),
                Custo = leitor.GetDecimal("custo_prod"),
                ValorVenda = leitor.GetDecimal("valor_venda_prod"),
                Status = leitor.GetString("status_prod"),
                DataCadastro = leitor.GetDateTime("data_cadastro_prod"),
                IdCategoria = leitor.GetInt32("id_cat_fk"),
                Categoria = leitor.GetString("nome_categoria")
            });
        }

        return produtos;
    }

    public void Adicionar(Produto produto)
    {
        using var conexao = _conexao.GetConnection();
        using var comando = conexao.CreateCommand();
        comando.CommandText = """
            INSERT INTO Produto
                (codigo_prod, nome_prod, descricao_prod, quantidade_prod, custo_prod,
                 valor_venda_prod, status_prod, data_cadastro_prod, id_cat_fk)
            VALUES
                (@codigo, @nome, @descricao, @quantidade, @custo,
                 @valorVenda, @status, @dataCadastro, @idCategoria);
            """;
        comando.Parameters.AddWithValue("@codigo", produto.Codigo.Trim());
        comando.Parameters.AddWithValue("@nome", produto.Nome.Trim());
        comando.Parameters.AddWithValue("@descricao", produto.Descricao.Trim());
        comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
        comando.Parameters.AddWithValue("@custo", produto.Custo);
        comando.Parameters.AddWithValue("@valorVenda", produto.ValorVenda);
        comando.Parameters.AddWithValue("@status", produto.Status);
        comando.Parameters.AddWithValue("@dataCadastro", produto.DataCadastro.Date);
        comando.Parameters.AddWithValue("@idCategoria", produto.IdCategoria);
        comando.ExecuteNonQuery();
        produto.Id = (int)comando.LastInsertedId;
    }

    public void Remover(int id)
    {
        using var conexao = _conexao.GetConnection();
        using var comando = conexao.CreateCommand();
        comando.CommandText = "DELETE FROM Produto WHERE id_prod = @id";
        comando.Parameters.AddWithValue("@id", id);
        comando.ExecuteNonQuery();
    }
}
