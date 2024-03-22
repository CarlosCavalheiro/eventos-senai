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
    public class EventosController : ControllerBase
    {
        private EventosDAO _eventosDAO;

        public EventosController()
        {
            _eventosDAO = new EventosDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var eventos = _eventosDAO.GetAll();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetEventoById(int id)
        {
            var evento = _eventosDAO.GetEventoById(id);
            if (evento == null)
                return NotFound();
            
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult CreateEvento(Evento evento)
        {
            _eventosDAO.CreateEvento(evento);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvento(int id, [FromBody] Evento evento)
        {
            var existingEvento = _eventosDAO.GetEventoById(id);

            if (existingEvento == null)
                return NotFound();

            _eventosDAO.UpdateEvento(id, evento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            var existingEvento = _eventosDAO.GetEventoById(id);

            if (existingEvento == null)
                return NotFound();

            _eventosDAO.DeleteEvento(id);
            return Ok();
        }
    }
}