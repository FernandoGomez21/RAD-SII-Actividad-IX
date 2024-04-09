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
    public class NPaciente
    {
        private DPaciente dPaciente;

        public NPaciente()
        {
            dPaciente = new DPaciente();
        }
        public List<Paciente> TodosLosPacientes()
        {
            return dPaciente.TodosLosPcientes();
        }

        public List<Paciente> PacientesActivos()
        {
            return dPaciente.TodosLosPcientes().Where(c => c.Estado == true).ToList();
        }
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var clientes = dPaciente.TodosLosPcientes()
                                      .Where(c => c.Estado == true).Select(c => new
                                      {
                                          c.PacienteId,
                                          c.PacienteCombo,
                                      })
                                      .ToList();
            foreach (var item in clientes)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.PacienteId,
                    Descripcion = item.PacienteCombo
                });
            }

            return Datos;
        }
        public int AgregarPaciente(Paciente paciente)
        {
            return dPaciente.GuardarPaciente(paciente);
        }

        public int EditarPaciente(Paciente paciente)
        {
            return dPaciente.GuardarPaciente(paciente);
        }

        public int EliminarPaciente(int pacienteId)
        {
            return dPaciente.EliminarPaciente(pacienteId);
        }

    }
}
