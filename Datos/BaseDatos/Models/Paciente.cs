using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(120)]
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }
}
