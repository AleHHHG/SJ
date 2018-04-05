using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJ.Models
{
    public class Pedido
    {
        public decimal valor_acrecimo { get; set; }
        public decimal valor_desconto { get; set; }
        public string observacao { get; set; }
        public int forma_pagamento { get; set; }
        public List<Produtos> itens { get; set; }

        public class Produtos
        {
            public int id { get; set; }
            public decimal valor { get; set; }
            public int quantidade { get; set; }
        }
    }
}