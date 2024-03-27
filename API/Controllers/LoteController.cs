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
    public class LoteController : ControllerBase
    {
        private LoteDAO _loteDAO;

        public LoteController()
        {
            _loteDAO = new LoteDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lotes = _loteDAO.GetAll();
            return Ok(lotes);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoteById(int id)
        {
            var lote = _loteDAO.GetLoteById(id);
            if (lote == null)
                return NotFound();
            
            return Ok(lote);
        }
        
        [HttpPost]
        public IActionResult CreateLote(Lote lote)
        {
            _loteDAO.CreateLote(lote);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLote(int id, [FromBody] Lote lote)
        {
            var existingLote = _loteDAO.GetLoteById(id);

            if (existingLote == null)
                return NotFound();

            _loteDAO.UpdateLote(lote);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLote(int id)
        {
            var existingLote = _loteDAO.GetLoteById(id);

            if (existingLote == null)
                return NotFound();

            _loteDAO.DeleteLote(id);
            return Ok();
        }
        
    }
}