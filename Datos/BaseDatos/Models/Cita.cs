using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }
        public bool Estado {  get; set; }

    }
}
