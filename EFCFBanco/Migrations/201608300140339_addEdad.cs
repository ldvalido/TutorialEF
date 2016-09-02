namespace EFCFBanco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEdad : DbMigration
    {
        public override void Up()
        {
            AddColumn("Clientes", "Edad", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("Clientes", "Edad");
        }
    }
}
