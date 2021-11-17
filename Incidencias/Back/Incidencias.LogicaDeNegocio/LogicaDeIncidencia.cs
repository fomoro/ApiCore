using Incidencias.InterfacesAccesoDatos;
using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.LogicaDeNegocio
{
    public class LogicaDeIncidencia : IIncidenciasLogica
    {
        private const string null_incidencia = "Incidencia";

        IIncidenciasRepositorio _repository;

        public LogicaDeIncidencia(IIncidenciasRepositorio repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> Actualizar(Incidencia entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_incidencia);
            }

            if (entity.EstatusIncidencia == Modelos.Enum.EstatusIncidencia.Resuelto) {
                if (entity.Duracion <= 0)
                {
                    throw new ArgumentException("Debe Ingresar Duracion");
                }
            }

            return await _repository.Actualizar(entity);
        }

        public async Task<Incidencia> Agregar(Incidencia entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_incidencia);
            }
            await _repository.Agregar(entity);
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await _repository.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Incidencia> ObtenerPorId(int id)
        {
            try
            {
                return await _repository.ObtenerAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Incidencia> ObtenerPorNombre(string nombre)
        {
            return await _repository.ObtenerNombreAsync(nombre);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerTodos()
        {
            try
            {
                return await _repository.ObtenerTodosAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}