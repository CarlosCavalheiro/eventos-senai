using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Evento
    {
        [Column("id_evento")]
        public int IdEvento { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("data_evento")]
        public DateTime DataEvento { get; set; }

        [Column("total_ingressos")]
        public int TotalIngressos { get; set; }

        [Column("imagem_url")]
        public string? ImagemURL { get; set; }

        [Column("local")]
        public string? Local { get; set; }

        [Column("status")]
        public int Ativo { get; set; }
    }
}