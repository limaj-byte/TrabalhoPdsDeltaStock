using DeltaStock.Configs;
using DeltaStock.Models;

namespace DeltaStock.DAO
{
    public class VendaDAO
    {
        private readonly Conexao _conexao;

        public VendaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Venda> Listar()
        {
            try
            {
                var lista = new List<Venda>();

                using var con = _conexao.GetConnection();

                const string sql = "SELECT id_ven, data_ven, valor_total_ven, status_ven, id_usu_fk FROM venda ORDER BY data_ven";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var venda = new Venda();

                    venda.Id = leitor.GetInt32("id_ven");

                    venda.Dataven = leitor.IsDBNull(leitor.GetOrdinal("data_ven"))
                        ? null
                        : leitor.GetDateTime("data_ven");

                    venda.Valortotalven = leitor.GetFloat("valor_total_ven");

                    venda.Statusven = leitor.IsDBNull(leitor.GetOrdinal("status_ven"))
                        ? ""
                        : leitor.GetString("status_ven");

                    venda.Idusufk = leitor.GetInt32("id_usu_fk");

                    lista.Add(venda);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public void Inserir(Venda venda)
        {
            ArgumentNullException.ThrowIfNull(venda);

            using var con = _conexao.GetConnection();

            const string sql = """
                INSERT INTO venda (data_ven, valor_total_ven, status_ven, id_usu_fk)
                VALUES (@data, @valorTotal, @status, @idUsuario);
                """;

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            comando.Parameters.AddWithValue("@data", venda.Dataven!.Value);
            comando.Parameters.AddWithValue("@valorTotal", venda.Valortotalven);
            comando.Parameters.AddWithValue("@status", venda.Statusven.Trim());
            comando.Parameters.AddWithValue("@idUsuario", venda.Idusufk);

            comando.ExecuteNonQuery();

            venda.Id = (int)comando.LastInsertedId;
        }
    }
}