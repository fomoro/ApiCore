using Incidencias.Interfaces.AccesoDatos;
using Incidencias.Interfaces.LogicaDeNegocio;
using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.LogicaDeNegocio
{
    public class LogicaDeProyectos : IProyectosLogica
    {
        private const string null_Proyecto = "Proyecto";

        IProyectosRepositorio _repository;

        public LogicaDeProyectos(IProyectosRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<bool> Actualizar(Proyecto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_Proyecto);
            }
            return await _repository.Actualizar(entity);
        }

        public async Task<Proyecto> Agregar(Proyecto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_Proyecto);
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

        public async Task<Proyecto> ObtenerConDetallesPorId(int id)
        {
            return await _repository.ObtenerConDetallesPorId(id);
        }

        public async Task<Proyecto> ObtenerPorId(int id)
        {
            try
            {
                return await _repository.ObtenerPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Proyecto> ObtenerPorNombre(string nombre)
        {
            return await _repository.ObtenerPorNombre(nombre);
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodos()
        {
            try
            {
                return await _repository.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodosConDetalle()
        {
            return await _repository.ObtenerTodosConDetalle();
        }
    }
}