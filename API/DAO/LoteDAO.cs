using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using API.Models;
using API.Repository;
using MySql.Data.MySqlClient;

namespace API.DAO
{
    public class LoteDAO
    {
        private MySqlConnection connection ;
        private EventosDAO _eventoDAO;

        public LoteDAO()
        {
            connection =  MySqlConnectionFactory.GetConnection();
            _eventoDAO = new EventosDAO();
        }

        // Método para buscar todos os lotes
        public List<LoteExibir> GetAll()
        {
            List<LoteExibir> lotes = new List<LoteExibir>();
            string query = "SELECT * FROM lote";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LoteExibir lote = new LoteExibir();
                        lote.IdLote = reader.GetInt32("id_lote");
                        lote.IdEvento = reader.GetInt32("id_evento");
                        lote.ValorUnitario = reader.GetDouble("valor_unitario");
                        lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                        lote.Saldo = reader.GetInt32("saldo");
                        lote.ativo = reader.GetInt32("ativo");
                        lote.Descricao = reader.IsDBNull("descricao") ? "" : reader.GetString("descricao");
                        lote.DataInicio = reader.GetDateTime("data_inicio");
                        lote.DataFim = reader.GetDateTime("data_fim");
                        lote.Evento = _eventoDAO.GetEventoById(lote.IdEvento);
                        lotes.Add(lote);
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
            return lotes;
        }

        // Método para buscar um lote pelo ID
        public LoteExibir GetLoteById(int id)
        {
            LoteExibir lote = new LoteExibir();
            var query = $"SELECT * FROM lote WHERE id_lote = {id}";   
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lote.IdLote = reader.GetInt32("id_lote");
                        lote.IdEvento = reader.GetInt32("id_evento");
                        lote.ValorUnitario = reader.GetDouble("valor_unitario");
                        lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                        lote.Saldo = reader.GetInt32("saldo");
                        lote.ativo = reader.GetInt32("ativo");
                        lote.Descricao = reader.IsDBNull("descricao") ? "" : reader.GetString("descricao");
                        lote.DataInicio = reader.GetDateTime("data_inicio");
                        lote.DataFim = reader.GetDateTime("data_fim");
                        lote.Evento = _eventoDAO.GetEventoById(lote.IdEvento);
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
            return lote;
        }

        // Método para criar um lote
        public void CreateLote(Lote lote)
        {
            string query = $"INSERT INTO lote (evento_id_evento, valor_unitario, quantidade_total, saldo, ativo, descricao, data_inicio, data_fim) VALUES (@evento_id_evento, @valor_unitario, @quantidade_total, @saldo, @ativo, '@descricao', '@data_inicio', '@data_fim')";
            
            try
            {
                lote.Saldo = lote.QuantidadeTotal;

                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@evento_id_evento", lote.IdEvento);
                command.Parameters.AddWithValue("@valor_unitario", lote.ValorUnitario);
                command.Parameters.AddWithValue("@quantidade_total", lote.QuantidadeTotal);
                command.Parameters.AddWithValue("@saldo", lote.Saldo);
                command.Parameters.AddWithValue("@ativo", lote.ativo);
                command.Parameters.AddWithValue("@descricao", lote.Descricao);
                command.Parameters.AddWithValue("@data_inicio", lote.DataInicio.ToString("DD/MM/yyyy HH:mm:ss"));
                command.Parameters.AddWithValue("@data_fim", lote.DataFim.ToString("DD/MM/yyyy HH:mm:ss"));

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

        // Método para atualizar um lote
        public void UpdateLote(Lote lote)
        {
            string query = $"UPDATE lote SET valor_unitario = @valor_unitario', quantidade_total = @quantidade_total, saldo = @saldo, ativo = @ativo, descricao = '@descricao', data_inicio = '@data_inicio', data_fim = '@data_fim' WHERE id_lote = @id_evento";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_evento", lote.IdEvento);
                command.Parameters.AddWithValue("@valor_unitario", lote.ValorUnitario);
                command.Parameters.AddWithValue("@quantidade_total", lote.QuantidadeTotal);
                command.Parameters.AddWithValue("@saldo", lote.Saldo);
                command.Parameters.AddWithValue("@ativo", lote.ativo);
                command.Parameters.AddWithValue("@descricao", lote.Descricao);
                command.Parameters.AddWithValue("@data_inicio", lote.DataInicio);
                command.Parameters.AddWithValue("@data_fim", lote.DataFim);
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

        // Método para deletar um lote
        public void DeleteLote(int id)
        {
            string query = $"DELETE FROM lote WHERE id_lote = {id}";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
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

        
    }
}