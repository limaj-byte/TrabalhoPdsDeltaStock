using DeltaStock.Components.Pages.Venda;
using DeltaStock.Configs;

namespace DeltaStock.DAO
{
    public class VendaDAO
    {
        private readonly Conexao _conexao;

        public VendaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public List<VendaDAO> Listar()
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
                    var venda = new Venda();

                    venda.Id = leitor.GetInt32("id_ven");
                    venda.Dataven = leitor.GetDateTime("data_ven");
                    venda.Valortotalven = leitor.GetFloat("valor_total_ven");
                    venda.Statusven = leitor.GetString("status_ven");
                    venda.Idusufk = leitor.GetInt16("id_usu_fk");

                    //Aqui estao os de categoria, no seu use o seu                                                                                                                                  
                    //id_cat int primary key auto_increment,
                    //nome_cat varchar(300),
                    //descricao_cat varchar(500),
                    //codigo_cat varchar(100),
                    //status_cat varchar(100),
                    //data_cadastro_cat date

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