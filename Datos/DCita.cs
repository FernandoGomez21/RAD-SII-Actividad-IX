using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos.Core;

namespace Datos
{
    public class DCita
    {
        UnitOfWork _unitOfWork;
        public DCita() {
          _unitOfWork = new UnitOfWork();
        }
        public int CitaId { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public DateTime FechaCita { get; set; }
        public bool Estado { get; set; }


        public List<Cita> TodosLasCitas()
        {
            return _unitOfWork.Repository<Cita>()
                                        .Consulta()
                                        .Include(c=> c.Medico)
                                        .Include(c=>c.Paciente)
                                        .ToList();
        }

        public int GuardarCita(Cita cita)
        {
            string FechaCita = cita.FechaCita.Year + "-" + cita.FechaCita.Month + "-" + cita.FechaCita.Day;
            if (cita.CitaId == 0)
            {
                _unitOfWork.Repository<Cita>().Agregar(cita);
                return _unitOfWork.Guardar();
            }

            else
            {
                var CitaeInDb = _unitOfWork.Repository<Cita>().Consulta().FirstOrDefault(c => c.CitaId == cita.CitaId);

                if (CitaeInDb != null)
                {
                    CitaeInDb.MedicoId = cita.MedicoId;
                    CitaeInDb.PacienteId = cita.PacienteId;
                    CitaeInDb.FechaCita = cita.FechaCita;
                    CitaeInDb.Estado = cita.Estado;
                    _unitOfWork.Repository<Cita>().Editar(cita);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int EliminarCita(int citaId)
        {
            var CitaeInDb = _unitOfWork.Repository<Cita>().Consulta().FirstOrDefault(c => c.CitaId == citaId);
            if (CitaeInDb != null)
            {
                _unitOfWork.Repository<Cita>().Eliminar(CitaeInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

    }
}
