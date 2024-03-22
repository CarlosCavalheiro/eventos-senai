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
        private readonly UsuariosDAO _usuarioDAO;

        public UsuariosController()
        {
            _usuarioDAO = new UsuariosDAO();
        }

        public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _usuarioDAO.GetUsuarios();
        return Ok(usuarios);
    } 

    }
}