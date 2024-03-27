using MySql.Data.MySqlClient;

namespace API.Repository
{
    public class MySqlConnectionFactory
    {
        public static MySqlConnection GetConnection()
        {
            //string connectionString = "Server=localhost;Database=bd_eventos_senailp;Uid=root;Pwd=123456;"; // Carlos
            string connectionString = "Server=localhost;Database=bd_eventos_senailp;Uid=root;Pwd=Sql123!@;"; // Rodolfo
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}