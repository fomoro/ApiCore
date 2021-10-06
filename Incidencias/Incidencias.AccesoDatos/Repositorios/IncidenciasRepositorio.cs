using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Microsoft.AspNetCore.Identity;
using Incidencias.Interfaces.AccesoDatos;

namespace Incidencias.AccesoDatos.Repositorios
{
    public class IncidenciasRepositorio : IIncidenciasRepositorio
    {
        private readonly Contexto _contexto;
        private readonly ILogger<IncidenciasRepositorio> _logger;
        private DbSet<Incidencia> _dbSet;
        public IncidenciasRepositorio(Contexto contexto, ILogger<IncidenciasRepositorio> logger)
        {
            this._contexto = contexto;
            this._logger = logger;            
            this._dbSet = _contexto.Set<Incidencia>();
        }

        public async Task<bool> Actualizar(Incidencia entity)
        {
            var incidenciaDb = await _dbSet.FirstOrDefaultAsync(u => u.Id == entity.Id);

            if (incidenciaDb == null)
            {
                _logger.LogError($"Error en {nameof(Actualizar)}: No existe la incidencia con Id: {entity.Id}");
                return false;
            }

            incidenciaDb.Nombre = entity.Nombre;
            incidenciaDb.EstatusIncidencia = entity.EstatusIncidencia;
            incidenciaDb.Descripcion = entity.Descripcion;
            incidenciaDb.Version = entity.Version;

            try
            {
                return await _contexto.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Actualizar)}: " + excepcion.Message);
            }
            return false;
        }

        public async Task<Incidencia> Agregar(Incidencia entity)
        {            
            entity.EstatusIncidencia = EstatusIncidencia.Activo;
            _dbSet.Add(entity);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Agregar)}: " + excepcion.Message);
            }
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            try
            {
                _dbSet.Remove(entity);
                return (await _contexto.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: " + excepcion.Message);
            }
            return false;            
        }

        public async Task<Incidencia> ObtenerAsync(int id)
        {
            return await _dbSet
                .Include(Incidencia => Incidencia.Proyecto)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerTodosAsync()
        {
            return await _dbSet
                .Include(Incidencia => Incidencia.Proyecto)
                .Where(u => u.EstatusIncidencia != EstatusIncidencia.Inactivo).ToListAsync();
        }

        public async Task<Incidencia> ObtenerNombreAsync(string nombre)
        {
            try
            {
                return await _dbSet
                    .Where(c => c.Nombre == nombre && c.EstatusIncidencia != EstatusIncidencia.Inactivo)
                    .FirstOrDefaultAsync();
            }
            catch (Exception excepcion)
            {
                return null;
                _logger.LogError($"Error en {nameof(ObtenerNombreAsync)}: " + excepcion.Message);
            }
        }
    }
}
