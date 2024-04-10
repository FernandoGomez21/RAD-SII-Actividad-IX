namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaCita : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        CitaId = c.Int(nullable: false, identity: true),
                        MedicoId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                        FechaCita = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CitaId)
                .ForeignKey("dbo.Medico", t => t.MedicoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.MedicoId)
                .Index(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Cita", "MedicoId", "dbo.Medico");
            DropIndex("dbo.Cita", new[] { "PacienteId" });
            DropIndex("dbo.Cita", new[] { "MedicoId" });
            DropTable("dbo.Cita");
        }
    }
}
