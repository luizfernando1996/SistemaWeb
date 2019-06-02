using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestWebSolut.Models
{
    public class LinhaPedido
    {
        [Key]
        public int Id { get; set; }

        public int IdProduto { get; set; }
        public Produto prod { get; set; }

        public int quantidade { get; set; }

        public int NumeroPedido { get; set; }
        public ClientePedido pedido { get; set; }
    }
}