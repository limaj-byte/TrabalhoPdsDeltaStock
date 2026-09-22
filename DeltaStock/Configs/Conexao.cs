using MySql.Data.MySqlClient;

namespace DeltaStock.Configs
{
    public class Conexao
    {

        private readonly string _connectionString;
        public Conexao(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection") ?? "";
        }

        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            // Cada operação do DAO recebe uma conexão já aberta.
            conn.Open();
            return conn;
        }

        public MySqlCommand CreateCommand(string query, MySqlConnection? conn = null)
        {
            conn ??= GetConnection();
            return new MySqlCommand(query, conn);
        }
    }
}
