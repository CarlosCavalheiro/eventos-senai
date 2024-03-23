using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Repository;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.DAO;

namespace API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosDAO _usuarioDAO;

        public UsuariosController()
        {
            _usuarioDAO = new UsuariosDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioDAO.GetAll();
            return Ok(usuarios);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = _usuarioDAO.GetUsuarioById(id);
            if (usuario == null)
                return NotFound();
            
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CreateUsuario(Usuario usuario)
        {
            _usuarioDAO.CreateUsuario(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            var existingUsuario = _usuarioDAO.GetUsuarioById(id);

            if (existingUsuario == null)
                return NotFound();

            _usuarioDAO.UpdateUsuario(id, usuario);
            return Ok();
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteUsuario(int id)
        {
            var existingUsuario = _usuarioDAO.GetUsuarioById(id);

            if (existingUsuario == null)
                return NotFound();

            _usuarioDAO.DeleteUsuario(id);
            return Ok();
        }

    }
}