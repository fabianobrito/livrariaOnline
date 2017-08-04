namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class livraria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Livros", "categoriaID", "dbo.Categorias");
            DropIndex("dbo.Livros", new[] { "categoriaID" });
            AlterColumn("dbo.Livros", "categoriaID", c => c.Int());
            CreateIndex("dbo.Livros", "categoriaID");
            AddForeignKey("dbo.Livros", "categoriaID", "dbo.Categorias", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livros", "categoriaID", "dbo.Categorias");
            DropIndex("dbo.Livros", new[] { "categoriaID" });
            AlterColumn("dbo.Livros", "categoriaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Livros", "categoriaID");
            AddForeignKey("dbo.Livros", "categoriaID", "dbo.Categorias", "id", cascadeDelete: true);
        }
    }
}
