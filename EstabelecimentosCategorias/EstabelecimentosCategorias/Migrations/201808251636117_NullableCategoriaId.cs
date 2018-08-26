namespace EstabelecimentosCategorias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableCategoriaId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estabelecimentoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Estabelecimentoes", new[] { "CategoriaId" });
            AlterColumn("dbo.Estabelecimentoes", "CategoriaId", c => c.Int());
            CreateIndex("dbo.Estabelecimentoes", "CategoriaId");
            AddForeignKey("dbo.Estabelecimentoes", "CategoriaId", "dbo.Categorias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estabelecimentoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Estabelecimentoes", new[] { "CategoriaId" });
            AlterColumn("dbo.Estabelecimentoes", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Estabelecimentoes", "CategoriaId");
            AddForeignKey("dbo.Estabelecimentoes", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
    }
}
