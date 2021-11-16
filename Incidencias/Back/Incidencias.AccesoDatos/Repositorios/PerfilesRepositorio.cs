using Incidencias.InterfacesAccesoDatos;
using Incidencias.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.AccesoDatos.Repositorios
{
    public class PerfilesRepositorio : IRepositorioGenerico<Perfil>
    {
        private readonly Contexto _contexto;
        private readonly ILogger<PerfilesRepositorio> _logger;
        private DbSet<Perfil> _dbSet;

        public PerfilesRepositorio(Contexto contexto, ILogger<PerfilesRepositorio> logger)
        {
            this._contexto = contexto;
            this._logger = logger;
            this._dbSet = _contexto.Set<Perfil>();
        }
        public async Task<bool> Actualizar(Perfil entity)
        {
            _dbSet.Attach(entity);
            _contexto.Entry(entity).State = EntityState.Modified;
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

        public async Task<Perfil> Agregar(Perfil entity)
        {
            _dbSet.Add(entity);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Agregar)}: " + excepcion.Message);
                return null;
            }
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(u => u.Id == id);
            _dbSet.Remove(entity);
            try
            {
                return (await _contexto.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: " + excepcion.Message);
            }
            return false;
        }

        public async Task<Perfil> ObtenerAsync(int id)
        {            
            try
            {
                var resultado = await _dbSet.SingleOrDefaultAsync(c => c.Id == id);
                return resultado;
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: " + excepcion.Message);
                return null;
            }
            
        }

        public async Task<IEnumerable<Perfil>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
