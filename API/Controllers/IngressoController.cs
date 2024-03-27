using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DAO;
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
    }
}