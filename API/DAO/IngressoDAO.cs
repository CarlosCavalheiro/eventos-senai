using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repository;
using MySql.Data.MySqlClient;

namespace API.DAO
{
    public class IngressoDAO
    {
        private MySqlConnection connection ;

        public IngressoDAO()
        {
            connection =  MySqlConnectionFactory.GetConnection();
        }

        public List<Ingresso> GetAll()
        {
            List<Ingresso> ingressos = new List<Ingresso>();
            string query = "SELECT * FROM ingresso";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ingresso ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.CodigoQR = reader.IsDBNull("codigo_qr") ? "" : reader.GetString("codigo_qr");
                        ingresso.Valor = reader.GetDouble("valor");
                        ingresso.Status = reader.IsDBNull("status") ? "" : reader.GetString("status");
                        ingresso.Tipo = reader.IsDBNull("tipo") ? "" : reader.GetString("tipo");
                        ingresso.DataUtilizacao = reader.IsDBNull("data_utilizacao") ? DateTime.MinValue :reader.GetDateTime("data_utilizacao");
                        ingressos.Add(ingresso);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return ingressos;
        }

        public Ingresso GetIngressoById(int id)
        {
            Ingresso ingresso = new Ingresso();
            string query = "SELECT * FROM ingresso WHERE id_ingresso = @id";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.CodigoQR = reader.IsDBNull("codigo_qr") ? "" : reader.GetString("codigo_qr");
                        ingresso.Valor = reader.GetDouble("valor");
                        ingresso.Status = reader.IsDBNull("status") ? "" : reader.GetString("status");
                        ingresso.Tipo = reader.IsDBNull("tipo") ? "" : reader.GetString("tipo");
                        ingresso.DataUtilizacao = reader.IsDBNull("data_utilizacao") ? DateTime.MinValue :reader.GetDateTime("data_utilizacao");
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return ingresso;
        }

        public void CreateIngresso(Ingresso ingresso)
        {
            string query = "INSERT INTO ingresso (codigo_qr, valor, status, tipo, pedido_id_pedido, lote_id_lote) VALUES (@codigo_qr, @valor, @status, @tipo, @pedido_id_pedido, @lote_id_lote)";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                //command.Parameters.AddWithValue("@codigo_qr", ingresso.CodigoQR);
                //criar um código QR aleatório para o ingresso usando guid
                command.Parameters.AddWithValue("@codigo_qr", Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("@valor", ingresso.Valor);
                command.Parameters.AddWithValue("@status", "RESERVADO");
                command.Parameters.AddWithValue("@tipo", ingresso.Tipo);
                command.Parameters.AddWithValue("@pedido_id_pedido", ingresso.IdPedido);
                command.Parameters.AddWithValue("@lote_id_lote", ingresso.IdLote);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Ingresso - Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateIngresso(int id, Ingresso ingresso)
        {
            string query = "UPDATE ingresso SET codigo_qr = @codigo_qr, valor = @valor, status = @status, tipo = @tipo, data_utilizacao = @data_utilizacao WHERE id_ingresso = @id";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo_qr", ingresso.CodigoQR);
                command.Parameters.AddWithValue("@valor", ingresso.Valor);
                command.Parameters.AddWithValue("@status", ingresso.Status);
                command.Parameters.AddWithValue("@tipo", ingresso.Tipo);
                command.Parameters.AddWithValue("@data_utilizacao", ingresso.DataUtilizacao);                
                command.Parameters.AddWithValue("@pedido_id_pedido", ingresso.IdPedido);
                command.Parameters.AddWithValue("@lote_id_lote", ingresso.IdLote);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteIngresso(int id)
        {
            string query = "DELETE FROM ingresso WHERE id_ingresso = @id";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public Ingresso GetIngressoByCodigoQR(string codigo_qr){
            Ingresso ingresso = new Ingresso();
            string query = "SELECT * FROM ingresso WHERE codigo_qr = @codigo_qr";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo_qr", codigo_qr);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.CodigoQR = reader.IsDBNull("codigo_qr") ? "" : reader.GetString("codigo_qr");
                        ingresso.Valor = reader.GetDouble("valor");
                        ingresso.Status = reader.IsDBNull("status") ? "" : reader.GetString("status");
                        ingresso.Tipo = reader.IsDBNull("tipo") ? "" : reader.GetString("tipo");
                        ingresso.DataUtilizacao = reader.IsDBNull("data_utilizacao") ? DateTime.MinValue :reader.GetDateTime("data_utilizacao");
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
        }
        return ingresso;
        } 
        public Ingresso GetIngressoByUsuario(int IdUsuario){
            Ingresso ingresso = new Ingresso();
            string query = "SELECT * FROM ingresso WHERE usuario_id_usuario = @usuario_id_usuario";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario_id_usuario", IdUsuario);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.CodigoQR = reader.IsDBNull("codigo_qr") ? "" : reader.GetString("codigo_qr");
                        ingresso.Valor = reader.GetDouble("valor");
                        ingresso.Status = reader.IsDBNull("status") ? "" : reader.GetString("status");
                        ingresso.Tipo = reader.IsDBNull("tipo") ? "" : reader.GetString("tipo");
                        ingresso.DataUtilizacao = reader.IsDBNull("data_utilizacao") ? DateTime.MinValue :reader.GetDateTime("data_utilizacao");
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
        }
        return ingresso;
        } 

        //metodo para retornar todos os ingressos disponiveis a serem validados
        public List<Ingresso> GetIngressosBy(string status)
        {
            List<Ingresso> ingressos = new List<Ingresso>();
            string query = $"SELECT * FROM ingresso WHERE status = '{status}'";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ingresso ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.CodigoQR = reader.IsDBNull("codigo_qr") ? "" : reader.GetString("codigo_qr");
                        ingresso.Valor = reader.GetDouble("valor");
                        ingresso.Status = reader.IsDBNull("status") ? "" : reader.GetString("status");
                        ingresso.Tipo = reader.IsDBNull("tipo") ? "" : reader.GetString("tipo");
                        ingresso.DataUtilizacao = reader.IsDBNull("data_utilizacao") ? DateTime.MinValue :reader.GetDateTime("data_utilizacao");
                        ingressos.Add(ingresso);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Aqui você pode tratar exceções específicas do MySQL
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Aqui você trata outras exceções gerais
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return ingressos;
        }
        
    }
}