namespace EstabelecimentosCategorias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimeDataCadastro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estabelecimentoes", "DataCadastro", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estabelecimentoes", "DataCadastro", c => c.DateTime(nullable: false));
        }
    }
}
