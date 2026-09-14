using DeltaStock.Configs;
using DeltaStock.Models;
using System.Data;
using System.Diagnostics;
using static Mysqlx.Expect.Open.Types.Condition.Types;

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

                string sql = "SELECT * FROM categoria";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var categoria = new Categoria();

                    categoria.Id = leitor.GetInt32("id_cat");
                    categoria.Nome = leitor.GetString("id_cat");
                    categoria.Descricao = leitor.GetString("descricao_cat");
                    categoria.Codigo = leitor.GetString("codigo_cat");
                    categoria.Status = leitor.GetString("status_cat");
                    categoria.DataCadastroCategoria = leitor.GetDateTime("data_cadastro_cat");

                    //Aqui estao os de categoria, no seu use o seu                                                                                                                                  
                    //id_cat int primary key auto_increment,
                    //nome_cat varchar(300),
                    //descricao_cat varchar(500),
                    //codigo_cat varchar(100),
                    //status_cat varchar(100),
                    //data_cadastro_cat date

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
