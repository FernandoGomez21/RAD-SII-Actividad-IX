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
    internal class NCita
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

            public List<Cita> CitasActivas()
            {
                return dCita.TodosLasCitas().Where(c => c.Estado == true).ToList();
            }
          
            public int AgregarCita(Cita cita)
            {
                return dCita.GuardarCita(cita);
            }

            public int EditarMedicos(Cita cita)
            {
                return dCita.GuardarCita(cita);
            }

            public int Eliminarcita(int medico)
            {
                return dCita.EliminarCita(medico);
            }

    }
}
