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
        private IngressoDAO _ingressoDAO;

        public PedidoController()
        {
            _pedidoDAO = new PedidoDAO();
            _ingressoDAO = new IngressoDAO();
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
            try{
            
            var pedidoCriado = _pedidoDAO.CreatePedido(pedido);

            foreach (var ingresso in pedido.Ingressos)
            {
                ingresso.IdPedido = pedidoCriado.IdPedido;
                _ingressoDAO.CreateIngresso(ingresso);
            }

            
            return Ok();

            }catch(Exception e){
                return BadRequest(e.Message);                

            }

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