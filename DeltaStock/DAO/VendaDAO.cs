using DeltaStock.Configs;
using DeltaStock.Models;
using System.Security.Cryptography.Xml;
using static Mysqlx.Expect.Open.Types.Condition.Types;

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

                string sql = "SELECT * FROM categoria";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    var venda = new Venda
                    {
                        Id = leitor.GetInt32("id_ven"),
                        Dataven = leitor.GetDateTime("data_ven"),
                        Valortotalven = leitor.GetFloat("valor_total_ven"),
                        Statusven = leitor.GetString("status_ven"),
                        Idusufk = leitor.GetInt16("id_usu_fk")
                    };

                    //id_ven int primary key auto_increment,
                    //data_ven datetime,
                    //valor_total_ven float,
                    //status_ven varchar(100),
                    //id_usu_fk int,
                    //foreign key(id_usu_fk) references Usuario(id_usu)

                    lista.Add(venda);
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