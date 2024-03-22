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
    public class UsuariosDAO
    {
        private  MySqlConnection connection ;

        public UsuariosDAO()
        {
            connection =  MySqlConnectionFactory.GetConnection();
        }
        
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM usuarios";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = reader.GetInt32("id");
                        usuario.NomeCompleto = reader.IsDBNull("nome_completo") ? "" : reader.GetString("nome_completo");
                        usuario.Email = reader.IsDBNull("email") ? "" : reader.GetString("email");
                        usuario.Senha = reader.IsDBNull("senha") ? "" : reader.GetString("senha");
                        usuario.Telefone = reader.IsDBNull("Telefone") ? "" : reader.GetString("telefone");
                        usuario.Perfil = reader.IsDBNull("perfil") ? "" : reader.GetString("perfil");
                        usuario.Ativo = reader.GetInt32("ativo");
                        usuarios.Add(usuario);
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

            return usuarios;
        }
        public Usuario GetUsuarioById(int id)
        {
            Usuario usuario = new Usuario();
            var query = $"SELECT * FROM usuarios WHERE id_usuario = {id}";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.IdUsuario = reader.GetInt32("id");
                        usuario.NomeCompleto = reader.IsDBNull("nome_completo") ? "" : reader.GetString("nome_completo");
                        usuario.Email = reader.IsDBNull("email") ? "" : reader.GetString("email");
                        usuario.Senha = reader.IsDBNull("senha") ? "" : reader.GetString("senha");
                        usuario.Telefone = reader.IsDBNull("Telefone") ? "" : reader.GetString("telefone");
                        usuario.Perfil = reader.IsDBNull("perfil") ? "" : reader.GetString("perfil");
                        usuario.Ativo = reader.GetInt32("ativo");
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
            return usuario;
        }
    }
}

            