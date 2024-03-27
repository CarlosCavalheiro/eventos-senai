using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repository;
using MySql.Data.MySqlClient;

namespace API.DAO
{
    public class PedidoDAO
    {
        //cria objeto de acesso a dados de pedido
        private MySqlConnection connection ;

        public PedidoDAO()
        {
            connection =  MySqlConnectionFactory.GetConnection();
        }

        //método para listar todos os pedidos
        public List<Pedido> GetAll()
        {
            List<Pedido> pedidos = new List<Pedido>();
            string query = "SELECT * FROM pedido";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pedido pedido = new Pedido();
                        pedido.IdPedido = reader.GetInt32("id_pedido");
                        pedido.IdUsuario = reader.GetInt32("usuario_id_usuario");
                        pedido.ValidacaoIdUsuario = reader.GetInt32("validacao_id_usuario");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetDouble("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pagamento");
                        pedido.Status = reader.GetString("status");
                        pedidos.Add(pedido);
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
            return pedidos;
        }

        //método para buscar pedido por id
        public Pedido GetPedidoById(int id)
        {
            Pedido pedido = new Pedido();
            UsuariosDAO usuariosDAO = new UsuariosDAO();
            var query = $"SELECT * FROM pedido WHERE id_pedido = {id}";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pedido.IdPedido = reader.GetInt32("id_pedido");
                        pedido.IdUsuario = reader.GetInt32("usuario_id_usuario");
                        pedido.ValidacaoIdUsuario = reader.GetInt32("validacao_id_usuario");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetDouble("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pagamento");
                        pedido.Status = reader.GetString("status");
                        pedido.Usuario = new Usuario();
                        pedido.Usuario = usuariosDAO.GetUsuarioById(pedido.IdUsuario);
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
            return pedido;
        }

        //método para inserir pedido no BD
        public Pedido CreatePedido(Pedido pedido)
        {
            string query = "INSERT INTO pedido (usuario_id_usuario, validacao_id_usuario, data, total, quantidade, forma_pagamento, status) VALUES (@usuario_id_usuario, @validacao_id_usuario, @data, @total, @quantidade, @forma_pagamento, @status)";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario_id_usuario", pedido.IdUsuario);
                command.Parameters.AddWithValue("@validacao_id_usuario", pedido.ValidacaoIdUsuario);
                command.Parameters.AddWithValue("@data", pedido.Data);
                command.Parameters.AddWithValue("@total", pedido.Total);
                command.Parameters.AddWithValue("@quantidade", pedido.Quantidade);
                command.Parameters.AddWithValue("@forma_pagamento", pedido.FormaPagamento);
                command.Parameters.AddWithValue("@status", pedido.Status);
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
            return pedido;
        }

        //método para atualizar pedido no BD
        public void UpdatePedido(int id, Pedido pedido)
        {
            string query = "UPDATE pedido SET usuario_id_usuario = @usuario_id_usuario, validacao_id_usuario = @validacao_id_usuario, data = @data, total = @total, quantidade = @quantidade, forma_pagamento = @forma_pagamento, status = @status WHERE id_pedido = @id_pedido";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario_id_usuario", pedido.IdUsuario);
                command.Parameters.AddWithValue("@validacao_id_usuario", pedido.ValidacaoIdUsuario);
                command.Parameters.AddWithValue("@data", pedido.Data);
                command.Parameters.AddWithValue("@total", pedido.Total);
                command.Parameters.AddWithValue("@quantidade", pedido.Quantidade);
                command.Parameters.AddWithValue("@forma_pagamento", pedido.FormaPagamento);
                command.Parameters.AddWithValue("@status", pedido.Status);
                command.Parameters.AddWithValue("@id_pedido", id);
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

        //método para deletar pedido no BD
        public void DeletePedido(int id)
        {
            string query = $"DELETE FROM pedido WHERE id_pedido = {id}";
            
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