namespace RestWebSolut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientePedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numeroMesa = c.Int(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinhaPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        quantidade = c.Int(nullable: false),
                        NumeroPedido = c.Int(nullable: false),
                        pedido_Id = c.Int(),
                        prod_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientePedidoes", t => t.pedido_Id)
                .ForeignKey("dbo.Produtoes", t => t.prod_Id)
                .Index(t => t.pedido_Id)
                .Index(t => t.prod_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(),
                        Categoria = c.String(),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinhaPedidoes", "prod_Id", "dbo.Produtoes");
            DropForeignKey("dbo.LinhaPedidoes", "pedido_Id", "dbo.ClientePedidoes");
            DropIndex("dbo.LinhaPedidoes", new[] { "prod_Id" });
            DropIndex("dbo.LinhaPedidoes", new[] { "pedido_Id" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.LinhaPedidoes");
            DropTable("dbo.ClientePedidoes");
        }
    }
}
