namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaMedico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        MedicoId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 120),
                        Apellidos = c.String(nullable: false, maxLength: 120),
                        FechaIngreso = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medico");
        }
    }
}
