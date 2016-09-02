namespace EFCFBanco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        CBU = c.String(),
                        Saldo = c.Double(nullable: false),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CuentaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuenta", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.Cuenta", new[] { "ClienteID" });
            DropTable("dbo.Cuenta");
            DropTable("dbo.Cliente");
        }
    }
}
