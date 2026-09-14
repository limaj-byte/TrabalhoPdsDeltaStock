using DeltaStock.Configs;
using DeltaStock.Models;
using System.Data;

namespace DeltaStock.DAO
{
    public class MovimentacaoDAO
    {
        private readonly Conexao _conexao;

        public MovimentacaoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Movimentacao> Listar()
        {
            try
            {
                var lista = new List<Movimentacao>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Movimentacao";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var movimentacao = new Movimentacao();

                    movimentacao.Id = leitor.GetInt32("id_mov");
                    movimentacao.Data = leitor.GetDateTime("data_mov");
                    movimentacao.Tipo = leitor.GetString("tipo_mov");
                    movimentacao.Quantidade = leitor.GetInt32("quantidade_mov");
                    movimentacao.SaldoAnterior = leitor.GetInt32("saldo_anterior_mov");
                    movimentacao.SaldoFinal = leitor.GetInt32("saldo_final_mov");
                    movimentacao.Origem = leitor.GetString("origem_mov");

                    // Tratamento para campos que aceitam NULL no banco
                    movimentacao.Id_documento = leitor.IsDBNull(leitor.GetOrdinal("id_documento_mov"))
                        ? null
                        : leitor.GetString("id_documento_mov");

                    movimentacao.Motivo = leitor.IsDBNull(leitor.GetOrdinal("motivo_mov"))
                        ? null
                        : leitor.GetString("motivo_mov");

                    //id_mov int primary key auto_increment,
                    //data_mov datetime,
                    //tipo_mov varchar(100),
                    //quantidade_mov int,
                    //saldo_anterior_mov int,
                    //saldo_final_mov int,
                    //origem_mov varchar(300),
                    //id_documento_mov varchar(300),
                    //motivo_mov varchar(500),
                    //id_prod_fk int,
                    //foreign key(id_prod_fk) references Produto(id_prod),
                    //id_usu_fk int,
                    //foreign key(id_usu_fk) references Usuario(id_usu)

                    lista.Add(movimentacao);
                }
                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}