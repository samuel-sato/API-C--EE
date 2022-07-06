namespace DesafioAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profissionals", "NomeCompleto", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Profissionals", "CPF", c => c.String(nullable: false));
            AlterColumn("dbo.Profissionals", "Cidade", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profissionals", "Cidade", c => c.String());
            AlterColumn("dbo.Profissionals", "CPF", c => c.String());
            AlterColumn("dbo.Profissionals", "NomeCompleto", c => c.String());
        }
    }
}
