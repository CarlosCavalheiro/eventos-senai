using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string perfil { get; set; }
        public int Status { get; set; }
    }
}