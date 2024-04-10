using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength (120)]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        public bool Estado {  get; set; }

        [NotMapped]
        public string MedicoCombo => $"{Nombre} - {Apellido}";

    }
}
