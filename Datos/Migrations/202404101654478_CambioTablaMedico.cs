namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTablaMedico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medico", "Nombre", c => c.String(nullable: false, maxLength: 120));
            AddColumn("dbo.Medico", "Apellido", c => c.String(nullable: false, maxLength: 120));
            DropColumn("dbo.Medico", "Nombres");
            DropColumn("dbo.Medico", "Apellidos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medico", "Apellidos", c => c.String(nullable: false, maxLength: 120));
            AddColumn("dbo.Medico", "Nombres", c => c.String(nullable: false, maxLength: 120));
            DropColumn("dbo.Medico", "Apellido");
            DropColumn("dbo.Medico", "Nombre");
        }
    }
}
