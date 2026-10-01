using DeltaStock.Configs;
using DeltaStock.Models;
using System.Data;

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
                string sql = "SELECT id_usu, nome_usu, email_usu, senha_usu, telefone_usu, endereco_usu, tipo_usu, status_usu FROM usuario";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var usuario = new Usuario
                    {
                        Id = leitor.GetInt32("id_usu"),
                        Nome = leitor.GetString("nome_usu"),
                        Email = leitor.GetString("email_usu"),
                        Senha = leitor.GetString("senha_usu"),
                        Telefone = leitor.IsDBNull(leitor.GetOrdinal("telefone_usu")) ? "" : leitor.GetString("telefone_usu"),
                        Endereco = leitor.IsDBNull(leitor.GetOrdinal("endereco_usu")) ? "" : leitor.GetString("endereco_usu"),
                        Tipo = leitor.GetString("tipo_usu"),
                        Status = leitor.GetString("status_usu")
                    };

                    lista.Add(usuario);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public void Inserir(Usuario usuario)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"INSERT INTO usuario
                    (nome_usu, email_usu, senha_usu, telefone_usu, endereco_usu, tipo_usu, status_usu)
                    VALUES
                    (@nome, @email, @senha, @telefone, @endereco, @tipo, @status)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                AddParameter(comando, "@nome", usuario.Nome);
                AddParameter(comando, "@email", usuario.Email);
                AddParameter(comando, "@senha", usuario.Senha);
                AddParameter(comando, "@telefone", usuario.Telefone);
                AddParameter(comando, "@endereco", usuario.Endereco);
                AddParameter(comando, "@tipo", usuario.Tipo);
                AddParameter(comando, "@status", usuario.Status);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        private static void AddParameter(IDbCommand command, string parameterName, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}