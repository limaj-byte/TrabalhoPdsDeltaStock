using DeltaStock.Configs;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace DeltaStock.DAO
{
    public class UsuarioDAO
    {
        private readonly Conexao _conexao;

        public UsuarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public List<UsuarioDAO> Listar()
        {
            try
            {
                var lista = new List<UsuarioDAO>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM categoria";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var categoria = new UsuarioDAO();

                    categoria.Id = leitor.GetInt32("id_cat");
                    categoria.Nome = leitor.GetString("id_cat");
                    categoria.Descricao = leitor.GetString("descricao_cat");
                    categoria.Codigo = leitor.GetString("codigo_cat");
                    categoria.Status = leitor.GetString("status_cat");
                    categoria.DataCadastroCategoria = leitor.GetDateTime("data_cadastro_cat");

                    //id_usu int primary key auto_increment,
                    // nome_usu varchar(300),
                    //email_usu varchar(300),
                    //senha_usu varchar(300),
                    //telefone_usu varchar(100),
                    // endereco_usu varchar(300),
                    //tipo_usu varchar(100),
                    //status_usu varchar(100)

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
