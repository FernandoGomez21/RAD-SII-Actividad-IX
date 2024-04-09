﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos.Core;

namespace Datos
{
    public class DMedico
    {
        UnitOfWork _unitOfWork;

        public DMedico() {
            _unitOfWork = new UnitOfWork();
        }

        public int MedicoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Medico> TodosLosMedicos()
        {
            return _unitOfWork.Repository<Medico>().Consulta().ToList();
        }

        public int GuardarMedicos(Medico medicos)
        {
            if (medicos.MedicoId == 0)
            {
                _unitOfWork.Repository<Medico>().Agregar(medicos);
                return _unitOfWork.Guardar();
            }
            
            else
            {
                var ClienteInDb = _unitOfWork.Repository<Medico>().Consulta().FirstOrDefault(c=>c.MedicoId ==medicos.MedicoId);

                if (ClienteInDb == null)
                {
                    ClienteInDb.Nombres = medicos.Nombres;
                    ClienteInDb.Apellidos = medicos.Apellidos;
                    ClienteInDb.Estado = medicos.Estado;

                    _unitOfWork.Repository<Medico>().Editar(medicos);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }
        
        public int EliminarMedicos(int medicosId)
        {
            var ClienteInDb = _unitOfWork.Repository<Medico>().Consulta().FirstOrDefault(c => c.MedicoId == medicosId);
            
            if ( ClienteInDb == null)
            {
                _unitOfWork.Repository<Medico>().Eliminar(ClienteInDb);
            }
            return 0;
        }
    }
}
