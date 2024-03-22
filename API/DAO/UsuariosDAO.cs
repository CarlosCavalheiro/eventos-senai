using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repository;
using MySql.Data.MySqlClient;

namespace API.DAO
{
    public class UsuariosDAO
    {
        private readonly MySqlConnection connection ;

        public UsuariosDAO()
        {
            connection =  MySqlConnectionFactory.GetConnection();
        }
        
        
        public async Task<List<dynamic>> GetUsuarios()
        {
            string query = "SELECT * FROM usuarios";

            try{
                connection.Open();
                var result = await connection.QueryAsync<dynamic>(query);
                return result.ToList();
            }
        }

        /// <summary>
        /// Método responsável por realizar a inserção de um novo usuário no banco de dados.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario.</param>
        /// <returns>Retorna verdadeiro caso a inserção seja realizada com sucesso.</returns>
        /// <remarks>Este método é assíncrono.</remarks>
        public async Task<bool> Insert(Usuario usuario)
        {
            var query = "INSERT INTO usuarios (nome_completo, email, senha, telefone, perfil) VALUES (@NomeCompleto, @Email, @Senha, @Telefone, @Perfil)";
            var result = await _connection.ExecuteAsync(query, usuario);
            return result > 0;
        }
        /// <summary>
        /// Método responsável por realizar a busca de um usuário específico no banco de dados.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <returns>Retorna o usuário encontrado.</returns>
        /// <remarks>Este método é assíncrono.</remarks>
        public async Task<Usuario> GetUsuario(int id)
        {
            var query = "SELECT * FROM usuarios WHERE id = @Id";
            var result = await _connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
            return result;
        }

         
    }
}