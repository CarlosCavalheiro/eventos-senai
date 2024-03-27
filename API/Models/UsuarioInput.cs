using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UsuarioInput
    {
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
    }
}