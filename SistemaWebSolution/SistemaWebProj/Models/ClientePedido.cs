using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebProj.Models
{
    public class ClientePedido
    {
        [Key]
        public int Id { get; set; }
        public int numeroMesa { get; set; }
        public double ValorTotal { get; set; }
    }
}