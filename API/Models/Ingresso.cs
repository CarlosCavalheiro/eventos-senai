using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Ingresso
    {
        //Cria objeto do Ingresso usando notação

        [Column("id_ingresso")]
        public int IdIngresso { get; set; }

        [Column("codigo_qr")]
        public string CodigoQR { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("data_utilizacao")]
        public DateTime? DataUtilizacao { get; set; }

        [ForeignKey("pedido_id_pedido")]
        public int IdPedido { get; set; }

        [ForeignKey("lote_id_lote")]
        public int IdLote { get; set; }
        
        
    }
}