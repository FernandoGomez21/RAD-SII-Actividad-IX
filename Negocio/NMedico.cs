using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.BaseDatos.Models;
using Negocio.Comun;

namespace Negocio
{
    public class NMedico
    {
        private DMedico dMedico;

        public NMedico() { 
            dMedico = new DMedico();
        }
        public List<Medico> TodosLosMedicos()
        {
            return dMedico.TodosLosMedicos();
        }

        public List<Medico> MedicosActivos()
        {
            return dMedico.TodosLosMedicos().Where(c => c.Estado == true).ToList();
        }
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var clientes = dMedico.TodosLosMedicos()
                                      .Where(c => c.Estado == true).Select(c => new
                                      {
                                          c.MedicoId,
                                          c.MedicoCombo,
                                      })
                                      .ToList();
            foreach (var item in clientes)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.MedicoId,
                    Descripcion = item.MedicoCombo
                });
            }

            return Datos;
        }
        public int AgregarMedicos(Medico medico)
        {
            return dMedico.GuardarMedicos(medico);
        }

        public int EditarMedicos(Medico medico)
        {
            return dMedico.GuardarMedicos(medico);
        }

        public int EliminarMedicos(int medico)
        {
            return dMedico.EliminarMedicos(medico);
        }


    }
}
