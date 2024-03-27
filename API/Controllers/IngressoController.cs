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
    public class IngressoController : ControllerBase
    {
        private IngressoDAO _ingressoDAO;
        
        public IngressoController()
        {
            _ingressoDAO = new IngressoDAO();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var ingressos = _ingressoDAO.GetAll();
            return Ok(ingressos);
        }

        [HttpGet("{id}")]
        public IActionResult GetIngressoById(int id)
        {
            var ingresso = _ingressoDAO.GetIngressoById(id);
            if (ingresso == null)
                return NotFound();
            
            return Ok(ingresso);
        }

        [HttpPost]
        public IActionResult CreateIngresso(Ingresso ingresso)
        {
            _ingressoDAO.CreateIngresso(ingresso);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateIngresso(int id, [FromBody] Ingresso ingresso)
        {
            var existingIngresso = _ingressoDAO.GetIngressoById(id);

            if (existingIngresso == null)
                return NotFound();

            _ingressoDAO.UpdateIngresso(id, ingresso);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIngresso(int id)
        {
            var existingIngresso = _ingressoDAO.GetIngressoById(id);

            if (existingIngresso == null)
                return NotFound();

            _ingressoDAO.DeleteIngresso(id);
            return Ok();
        }

        

    }
}