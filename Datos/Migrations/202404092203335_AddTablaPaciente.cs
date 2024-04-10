namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaPaciente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        PacienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 120),
                        Apellidos = c.String(nullable: false, maxLength: 120),
                        FechaIngreso = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Paciente");
        }
    }
}
