using DeltaStock.Configs;
using DeltaStock.Models;
using System.Data;

namespace DeltaStock.DAO
{
    /// <summary>
    /// Classe responsável por realizar a comunicação direta com o banco de dados MySQL
    /// para operações relacionadas às movimentações de estoque (Camada DAO).
    /// </summary>
    public class MovimentacaoDAO
    {
        // Instância responsável por fornecer a conexão ativa com o banco de dados
        private readonly Conexao _conexao;

        // Construtor com Injeção de Dependência da classe Conexao
        public MovimentacaoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        /// <summary>
        /// Busca e retorna a lista completa de movimentações registradas no banco.
        /// </summary>
        public List<Movimentacao> Listar()
        {
            try
            {
                var lista = new List<Movimentacao>();

                // Abre/Gerencia a conexão com o banco (o 'using' fecha a conexão automaticamente no final)
                using var con = _conexao.GetConnection();

                // Define e prepara a instrução SQL a ser executada
                string sql = "SELECT * FROM Movimentacao";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                // Executa a consulta e obtém o leitor de dados
                using var leitor = comando.ExecuteReader();

                // Percorre registro por registro retornado pelo banco
                while (leitor.Read())
                {
                    var movimentacao = new Movimentacao();

                    // Mapeamento dos campos do banco para as propriedades do objeto C#
                    movimentacao.Id = leitor.GetInt32("id_mov");
                    movimentacao.Data = leitor.GetDateTime("data_mov");
                    movimentacao.Tipo = leitor.GetString("tipo_mov");
                    movimentacao.Quantidade = leitor.GetInt32("quantidade_mov");
                    movimentacao.SaldoAnterior = leitor.GetInt32("saldo_anterior_mov");
                    movimentacao.SaldoFinal = leitor.GetInt32("saldo_final_mov");
                    movimentacao.Origem = leitor.GetString("origem_mov");

                    // Tratamento obrigatório para campos que podem vir como NULL no MySQL
                    // Evita exceções do tipo SqlNullValueException
                    movimentacao.Id_documento = leitor.IsDBNull(leitor.GetOrdinal("id_documento_mov"))
                        ? null
                        : leitor.GetString("id_documento_mov");

                    movimentacao.Motivo = leitor.IsDBNull(leitor.GetOrdinal("motivo_mov"))
                        ? null
                        : leitor.GetString("motivo_mov");

                    // Adiciona o objeto preenchido à lista
                    lista.Add(movimentacao);
                }

                return lista;
            }
            catch
            {
                // Repassa a exceção capturada para tratar na camada de apresentação (View/Componente)
                throw;
            }
        }
    }
}