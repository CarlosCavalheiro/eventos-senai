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
            string query = "SELECT * FROM usuario";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = reader.GetInt32("id_usuario");
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
            var query = $"SELECT * FROM usuario WHERE id_usuario = {id}";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.IdUsuario = reader.GetInt32("id_usuario");
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

        public void CreateUsuario(Usuario usuario)
        {
            string query = "INSERT INTO usuario (nome_completo, email, senha, telefone, perfil) VALUES (@nome_completo, @email, @senha, @telefone, @perfil)";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome_completo", usuario.NomeCompleto);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@senha", usuario.Senha);
                command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                command.Parameters.AddWithValue("@perfil", usuario.Perfil);
                //command.Parameters.AddWithValue("@ativo", usuario.Ativo);
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
                Console.WriteLine($"Erro ao inserir usuário: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateUsuario(int id, Usuario usuario)
        {
            string query = "UPDATE usuario SET nome_completo = @nome_completo, email = @email, senha = @senha, telefone = @telefone, perfil = @perfil, ativo = @ativo WHERE id_usuario = @id_usuario";
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome_completo", usuario.NomeCompleto);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@senha", usuario.Senha);
                command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                command.Parameters.AddWithValue("@perfil", usuario.Perfil);
                command.Parameters.AddWithValue("@ativo", usuario.Ativo);
                command.Parameters.AddWithValue("@id_usuario", id);
                //command.Parameters.AddWithValue("@id_usuario", usuario.IdUsuario);
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
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteUsuario(int id)
        {
            string query = $"DELETE FROM usuario WHERE id_usuario = {id}";
            
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
                Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }


    }
}

            