namespace DesafioAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profissionals", "NumeroRegistro", c => c.Int(nullable: false));
            CreateIndex("dbo.Profissionals", "NumeroRegistro", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Profissionals", new[] { "NumeroRegistro" });
            DropColumn("dbo.Profissionals", "NumeroRegistro");
        }
    }
}
