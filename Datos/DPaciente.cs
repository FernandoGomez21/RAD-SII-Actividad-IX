using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos.Core;

namespace Datos
{
    public class DPaciente
    {

        UnitOfWork _unitOfWork;

        public DPaciente()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Paciente> TodosLosPcientes()
        {
            return _unitOfWork.Repository<Paciente>().Consulta().ToList();
        }

        public int GuardarPaciente(Paciente paciente)
        {
            if (paciente.PacienteId == 0)
            {
                _unitOfWork.Repository<Paciente>().Agregar(paciente);
                return _unitOfWork.Guardar();
            }

            else
            {
                var PacienteInDb = _unitOfWork.Repository<Paciente>().Consulta().FirstOrDefault(c => c.PacienteId == paciente.PacienteId);

                if (PacienteInDb != null)
                {
                    PacienteInDb.Nombres = paciente.Nombres;
                    PacienteInDb.Apellidos = paciente.Apellidos;
                    PacienteInDb.Estado = paciente.Estado;
                    _unitOfWork.Repository<Paciente>().Editar(paciente);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int EliminarPaciente(int pacienteId)
        {
            var PacienteInDb = _unitOfWork.Repository<Paciente>().Consulta().FirstOrDefault(c => c.PacienteId == pacienteId);
            if (PacienteInDb != null)
            {
                _unitOfWork.Repository<Paciente>().Eliminar(PacienteInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

    }
}
