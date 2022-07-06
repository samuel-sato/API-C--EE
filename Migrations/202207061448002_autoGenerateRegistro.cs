namespace DesafioAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autoGenerateRegistro : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Profissionals", new[] { "NumeroRegistro" });
            DropPrimaryKey("dbo.Profissionals");
            AlterColumn("dbo.Profissionals", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Profissionals", "NumeroRegistro", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Profissionals", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Profissionals");
            AlterColumn("dbo.Profissionals", "NumeroRegistro", c => c.Int(nullable: false));
            AlterColumn("dbo.Profissionals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Profissionals", "Id");
            CreateIndex("dbo.Profissionals", "NumeroRegistro", unique: true);
        }
    }
}
