using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Lote
    {
        [Column("id_lote")]
        public int IdLote { get; set; }
        [ForeignKey("evento_id_evento")]
        public int IdEvento { get; set; }
        [Column("valor_unitario")]
        public double ValorUnitario  { get; set; }
        [Column("quantidade_total")]
        public int QuantidadeTotal { get; set; }
        [Column("saldo")]
        public int Saldo { get; set; }
        [Column("ativo")]
        public int ativo { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }
        [Column("data_fim")]
        public DateTime DataFim { get; set; }   
             
    }
}