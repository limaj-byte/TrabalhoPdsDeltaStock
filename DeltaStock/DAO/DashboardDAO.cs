using DeltaStock.Configs;

namespace DeltaStock.DAO;

public sealed class DashboardDAO
{
    private readonly Conexao _conexao;

    public DashboardDAO(Conexao conexao) => _conexao = conexao;

    public DashboardResumo ObterResumo(DateTime referencia)
    {
        var inicioMes = new DateTime(referencia.Year, referencia.Month, 1);
        var inicioProximoMes = inicioMes.AddMonths(1);

        using var conexao = _conexao.GetConnection();
        using var comando = conexao.CreateCommand();
        comando.CommandText = """
            SELECT
                (SELECT COUNT(*) FROM Produto) AS total_produtos,
                (SELECT COUNT(*) FROM Movimentacao WHERE tipo_mov = 'ENTRADA' AND data_mov >= @inicioMes AND data_mov < @inicioProximoMes) AS entradas_mes,
                (SELECT COUNT(*) FROM Movimentacao WHERE tipo_mov = 'SAIDA' AND data_mov >= @inicioMes AND data_mov < @inicioProximoMes) AS saidas_mes,
                (SELECT COALESCE(SUM((iv.valor_unitario_item - p.custo_prod) * iv.quantidade_item), 0)
                 FROM ItemVenda iv
                 INNER JOIN Venda v ON v.id_ven = iv.id_ven_fk
                 INNER JOIN Produto p ON p.id_prod = iv.id_prod_fk
                 WHERE v.status_ven = 'Concluída') AS lucro_bruto;
            """;
        comando.Parameters.AddWithValue("@inicioMes", inicioMes);
        comando.Parameters.AddWithValue("@inicioProximoMes", inicioProximoMes);

        using var leitor = comando.ExecuteReader();
        leitor.Read();
        return new DashboardResumo(
            leitor.GetInt32("total_produtos"),
            leitor.GetInt32("entradas_mes"),
            leitor.GetInt32("saidas_mes"),
            leitor.GetDecimal("lucro_bruto"));
    }

    public List<ProdutoEstoqueBaixo> ListarEstoqueBaixo(int limite = 5)
    {
        using var conexao = _conexao.GetConnection();
        using var comando = conexao.CreateCommand();
        comando.CommandText = """
            SELECT nome_prod, quantidade_prod
            FROM Produto
            WHERE quantidade_prod <= @limite
            ORDER BY quantidade_prod, nome_prod
            LIMIT 4;
            """;
        comando.Parameters.AddWithValue("@limite", limite);

        using var leitor = comando.ExecuteReader();
        var produtos = new List<ProdutoEstoqueBaixo>();
        while (leitor.Read())
        {
            produtos.Add(new ProdutoEstoqueBaixo(
                leitor.GetString("nome_prod"),
                leitor.GetInt32("quantidade_prod")));
        }
        return produtos;
    }

    public List<MovimentacaoRecente> ListarUltimasMovimentacoes()
    {
        using var conexao = _conexao.GetConnection();
        using var comando = conexao.CreateCommand();
        comando.CommandText = """
            SELECT m.tipo_mov, m.quantidade_mov, p.nome_prod
            FROM Movimentacao m
            INNER JOIN Produto p ON p.id_prod = m.id_prod_fk
            ORDER BY m.data_mov DESC, m.id_mov DESC
            LIMIT 4;
            """;

        using var leitor = comando.ExecuteReader();
        var movimentacoes = new List<MovimentacaoRecente>();
        while (leitor.Read())
        {
            movimentacoes.Add(new MovimentacaoRecente(
                leitor.GetString("tipo_mov"),
                leitor.GetInt32("quantidade_mov"),
                leitor.GetString("nome_prod")));
        }
        return movimentacoes;
    }
}

public sealed record DashboardResumo(int TotalProdutos, int EntradasMes, int SaidasMes, decimal LucroBruto);
public sealed record ProdutoEstoqueBaixo(string Nome, int Quantidade);
public sealed record MovimentacaoRecente(string Tipo, int Quantidade, string Produto);
