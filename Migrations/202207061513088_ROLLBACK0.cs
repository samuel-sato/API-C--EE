namespace DesafioAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ROLLBACK0 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Profissionals");
            AlterColumn("dbo.Profissionals", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Profissionals", "NumeroRegistro", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Profissionals", "Id");
            CreateIndex("dbo.Profissionals", "NumeroRegistro", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Profissionals", new[] { "NumeroRegistro" });
            DropPrimaryKey("dbo.Profissionals");
            AlterColumn("dbo.Profissionals", "NumeroRegistro", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Profissionals", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Profissionals", "Id");
        }
    }
}
