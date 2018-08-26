namespace EstabelecimentosCategorias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToCategoriaNome : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categorias", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categorias", "Nome", c => c.String());
        }
    }
}
