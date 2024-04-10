using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos;
using Negocio.Comun;

namespace Negocio
{
    public class NCita
    {
        
            private DCita dCita;

            public NCita()
            {
                dCita = new DCita();
            }
            public List<Cita> TodasLasCitas()
            {
                return dCita.TodosLasCitas();
            }
            public List<Cita> obtenerClientesGrid()
            {
                var citas = dCita.TodosLasCitas().Select(c => new { c.CitaId, c.MedicoId, c.Medico.Nombre, c.Paciente.Nombres,c.FechaCita,c.Estado });
                return dCita.TodosLasCitas().ToList();
            }
        public List<Cita> CitasActivas()
            {
                dCita.TodosLasCitas().Where(c => c.Estado == true).ToList();
                var citas = dCita.TodosLasCitas().Select(c => new { c.CitaId, c.MedicoId, c.Medico.Nombre, c.Paciente.Nombres, c.FechaCita, c.Estado });
                return dCita.TodosLasCitas().ToList();
             }

        public int AgregarCita(Cita cita)
            {
                return dCita.GuardarCita(cita);
            }

            public int Editarcita(Cita cita)
            {
                return dCita.GuardarCita(cita);
            }

            public int Eliminarcita(int medico)
            {
                return dCita.EliminarCita(medico);
            }

    }
}
