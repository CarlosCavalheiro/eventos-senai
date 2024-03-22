using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Lote
    {
        public int IdLote { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QtdIngressos { get; set; }
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
        
    }
}