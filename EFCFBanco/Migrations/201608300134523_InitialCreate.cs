namespace EFCFBanco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        CBU = c.String(),
                        Saldo = c.Double(nullable: false),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CuentaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuentas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Cuentas", new[] { "ClienteID" });
            DropTable("dbo.Cuentas");
            DropTable("dbo.Clientes");
        }
    }
}
