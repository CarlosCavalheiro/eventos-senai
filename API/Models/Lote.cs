using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Lote
    {
        public int IdLote { get; set; }
        public int IdEvento { get; set; }
        public double ValorUnitario  { get; set; }
        public int QuantidadeTotal { get; set; }
        public int Saldo { get; set; }
        public int ativo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Evento Evento { get; set; }
        
    }
}