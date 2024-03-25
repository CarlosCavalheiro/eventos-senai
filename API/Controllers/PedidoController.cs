using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DAO;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private PedidoDAO _pedidoDAO;

        public PedidoController()
        {
            _pedidoDAO = new PedidoDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _pedidoDAO.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPedidoById(int id)
        {
            var pedido = _pedidoDAO.GetPedidoById(id);
            if (pedido == null)
                return NotFound();
            
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult CreatePedido(Pedido pedido)
        {
            _pedidoDAO.CreatePedido(pedido);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, [FromBody] Pedido pedido)
        {
            var existingPedido = _pedidoDAO.GetPedidoById(id);

            if (existingPedido == null)
                return NotFound();

            _pedidoDAO.UpdatePedido(id, pedido);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var existingPedido = _pedidoDAO.GetPedidoById(id);

            if (existingPedido == null)
                return NotFound();

            _pedidoDAO.DeletePedido(id);
            return Ok();
        }

    }
}