using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;

namespace Datos.BaseDatos
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext() : base("name= ClinicaMedica")
        {
        
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Utilizamos using System.Data.Entity.ModelConfiguration.Conventions;
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //No queremos Nombres en plural
        }

        public DbSet <Medico> medicos { get; set; }
        public DbSet<Paciente> paciente { get; set;}
        public DbSet<Cita> citas { get; set; }
    }
}
