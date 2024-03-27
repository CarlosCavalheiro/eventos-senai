using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PedidoExibir
    {
        //cria modelo de pedido de ingresso com campos necessários
        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [ForeignKey("usuario_id_usuario")]
        public int IdUsuario { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("total")]
        public double Total { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("forma_pagamento")]
        public string? FormaPagamento { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("validacao_id_usuario")]
        public int ValidacaoIdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        public List<Ingresso> Ingressos { get; set; } = new();

    }
}