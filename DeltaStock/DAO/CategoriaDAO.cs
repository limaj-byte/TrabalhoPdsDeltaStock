using DeltaStock.Configs;
using DeltaStock.Models;

namespace DeltaStock.DAO
{
    public class CategoriaDAO
    {
        private readonly Conexao _conexao;

        public CategoriaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public List<Categoria> Listar()
        {
            try
            {
                var lista = new List<Categoria>();

                using var con = _conexao.GetConnection();

                const string sql = "SELECT id_cat, nome_cat, descricao_cat, codigo_cat, status_cat, data_cadastro_cat FROM categoria ORDER BY nome_cat";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var categoria = new Categoria();

                    categoria.Id = leitor.GetInt32("id_cat");
                    categoria.Nome = leitor.GetString("nome_cat");

                    categoria.Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_cat"))
                        ? ""
                        : leitor.GetString("descricao_cat");

                    categoria.Codigo = leitor.IsDBNull(leitor.GetOrdinal("codigo_cat"))
                        ? ""
                        : leitor.GetString("codigo_cat");

                    categoria.Status = leitor.IsDBNull(leitor.GetOrdinal("status_cat"))
                        ? ""
                        : leitor.GetString("status_cat");

                    categoria.DataCadastroCategoria = leitor.IsDBNull(leitor.GetOrdinal("data_cadastro_cat"))
                        ? DateTime.MinValue
                        : leitor.GetDateTime("data_cadastro_cat");

                    lista.Add(categoria);
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
