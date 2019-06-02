using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestWebSolut.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}