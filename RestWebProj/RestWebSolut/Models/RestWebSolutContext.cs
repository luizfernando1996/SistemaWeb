using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestWebSolut.Models
{
    public class RestWebSolutContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RestWebSolutContext() : base("name=RestWebSolutContext")
        {
        }

        public System.Data.Entity.DbSet<RestWebSolut.Models.Produto> Produto { get; set; }

        public System.Data.Entity.DbSet<RestWebSolut.Models.LinhaPedido> LinhaPedido { get; set; }

        public System.Data.Entity.DbSet<RestWebSolut.Models.ClientePedido> ClientePedidoes { get; set; }
    }
}
