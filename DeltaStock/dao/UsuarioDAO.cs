using DeltaStock.Configs;
using DeltaStock.Models;
using System.Data;
using System.Diagnostics;
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
        public List<Usuario> Listar()
        {
            try
            {
                var lista = new List<Usuario>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM usuario";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = leitor.GetInt32("id_usu");
                    usuario.Nome = leitor.GetString("nome_usu");
                    usuario.Email = leitor.GetString("email_usu");
                    usuario.Senha = leitor.GetString("senha_usu");
                    usuario.Telefone = leitor.GetString("telefone_usu");
                    usuario.Endereco = leitor.GetDateTime("endereco_usu");
                    usuario.Tipo = leitor.GetDateTime("tipo_usu");
                    usuario.Status = leitor.GetDateTime("status_usu");

                    //id_usu int primary key auto_increment,
                    //nome_usu varchar(300),
                    //email_usu varchar(300),
                    //senha_usu varchar(300),
                    //telefone_usu varchar(100),
                    // endereco_usu varchar(300),
                    //tipo_usu varchar(100),
                    //status_usu varchar(100)

                    lista.Add(usuario);
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
