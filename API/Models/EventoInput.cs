using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class EventoInput
    {
        [Column("id_evento")]
        public int IdEvento { get; set; }
    
    }
}