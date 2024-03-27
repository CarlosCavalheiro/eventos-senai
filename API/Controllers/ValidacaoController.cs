using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DAO;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidacaoController : ControllerBase
    {
        private IngressoDAO _ingressoDAO;
        public ValidacaoController()
        {
            _ingressoDAO = new IngressoDAO();
        }
        [HttpPut("{codigo_qr}")]
        public IActionResult GetIngressoByCodigoQR(string codigo_qr)
        {
            var ingresso = _ingressoDAO.GetIngressoByCodigoQR(codigo_qr);
            if (ingresso == null)
                return NotFound();
            else
                return Ok(ingresso);
        }
        

        [HttpPost]
        public IActionResult ValidaIngresso(Ingresso ingresso)
        {

            //Se o ingresso estiver ativo, ele é desativado e retorna a mensagem de que foi validado com sucesso
            if (ingresso.Status == "ATIVO")
            {
                ingresso.Status = "VALIDADO";
                ingresso.DataUtilizacao = DateTime.Now;
                _ingressoDAO.UpdateIngresso(ingresso.IdIngresso, ingresso);
                return Ok("Ingresso validado com sucesso!");
            } else {
                return Ok("Ingresso indisponivel ou já foi validado!");
            }
        }

        //endpoint para retornar todos os ingressos disponiveis a serem validados
        //[Authorize(Policy ="PodeValidar")]//policies para autorizar o usuario a acessar o endpoint
        [HttpGet("{status}")]
        public ActionResult<IEnumerable<Ingresso>> GetIngressosDisponiveis(string status)
        {
            var ingressos = _ingressoDAO.GetIngressosBy(status);
            return Ok(ingressos);
        }

        
    }
}