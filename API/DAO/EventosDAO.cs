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
    public class EventosDAO
    {
       private MySqlConnection connection;

        public EventosDAO()
        {
            connection = MySqlConnectionFactory.GetConnection();
        } 

        public List<Evento> GetAll()
        {
            List<Evento> eventos = new List<Evento>();
            string query = "SELECT * FROM evento";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                {                        
                        
                        Evento evento = new Evento();
                        evento.IdEvento = reader.GetInt32("id_evento");
                        evento.Descricao = reader.IsDBNull("descricao") ? "" : reader.GetString("descricao");
                        evento.DataEvento = reader.GetDateTime("data_evento");                       
                        evento.TotalIngressos = reader.GetInt32("total_ingressos");
                        evento.ImagemURL = reader.IsDBNull("imagem_url") ? "" : reader.GetString("imagem_url"); 
                        evento.Local = reader.IsDBNull("local") ? "" : reader.GetString("local");
                        evento.Ativo = reader.GetInt32("ativo");
                        eventos.Add(evento);
                        
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
            
            return eventos;
        }    


        public Evento GetEventoById(int id)
        {
            Evento evento = new Evento();
            var query = $"SELECT * FROM evento WHERE id_evento = {id}";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {                        
                        evento.IdEvento = reader.GetInt32("id_evento");
                        evento.Descricao = reader.IsDBNull("descricao") ? "" : reader.GetString("descricao");
                        evento.DataEvento = reader.GetDateTime("data_evento");                       
                        evento.TotalIngressos = reader.GetInt32("total_ingressos");
                        evento.ImagemURL = reader.IsDBNull("imagem_url") ? "" : reader.GetString("imagem_url"); 
                        evento.Local = reader.IsDBNull("local") ? "" : reader.GetString("local");
                        evento.Ativo = reader.GetInt32("ativo"); 

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
                Console.WriteLine("Erro ao buscar o evento por ID: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return evento;
        }

        public void CreateEvento(Evento evento)
        {
            string query = "INSERT INTO evento (descricao, data_evento, total_ingressos, imagem_url, local, ativo) VALUES (@descricao, @data_evento, @total_ingressos, @imagem_url, @local, @ativo)";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@descricao", evento.Descricao);
                command.Parameters.AddWithValue("@data_evento", evento.DataEvento);
                command.Parameters.AddWithValue("@total_ingressos", evento.TotalIngressos);
                command.Parameters.AddWithValue("@imagem_url", evento.ImagemURL);
                command.Parameters.AddWithValue("@local", evento.Local);
                command.Parameters.AddWithValue("@ativo", evento.Ativo);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de BD inserir o evento: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir o evento: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateEvento(int id, Evento evento)
        {
            string query = "UPDATE evento SET descricao = @descricao, data_evento = @data_evento, total_ingressos = @total_ingressos, imagem_url = @imagem_url, local = @local, ativo = @ativo WHERE id_evento = @id_evento";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@descricao", evento.Descricao);
                command.Parameters.AddWithValue("@total_ingressos", evento.TotalIngressos);
                command.Parameters.AddWithValue("@data_evento", evento.DataEvento);
                command.Parameters.AddWithValue("@imagem_url", evento.ImagemURL);
                command.Parameters.AddWithValue("@local", evento.Local);
                command.Parameters.AddWithValue("@ativo", evento.Ativo);                
                command.Parameters.AddWithValue("@id_evento", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro no BD ao atualizar o evento: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar o evento: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteEvento(int id)
        {
            string query = $"DELETE FROM evento WHERE id_evento = {id}";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro no BD ao deletar o evento: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar o evento: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


    }
}