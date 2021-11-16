using Incidencias.Interfaces.AccesoDatos;
using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Incidencias.AccesoDatos.Repositorios
{
    public class ProyectosRepositorio : IProyectosRepositorio
    {
        private readonly Contexto _contexto;
        private readonly ILogger<ProyectosRepositorio> _logger;
        private DbSet<Proyecto> _dbSet;
  
        public ProyectosRepositorio(Contexto contexto, ILogger<ProyectosRepositorio> logger)
        {
            this._contexto = contexto;
            this._logger = logger;
            this._dbSet = _contexto.Set<Proyecto>();
        }
        
        public async Task<bool> Actualizar(Proyecto entity)
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

        public async Task<Proyecto> Agregar(Proyecto entity)
        {
            entity.EstatusProyecto = EstatusProyecto.Activo;
            entity.FechaRegistro = DateTime.UtcNow;
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
            entity.EstatusProyecto = EstatusProyecto.Inactivo;
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

        public async Task<Proyecto> ObtenerPorId(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(c => c.Id == id
                                && c.EstatusProyecto == EstatusProyecto.Activo);
        }

        public async Task<Proyecto> ObtenerNombreAsync(string nombre)
        {                        
            try
            {                
                return await  _dbSet.Where(c => c.Nombre == nombre && c.EstatusProyecto == EstatusProyecto.Activo).FirstOrDefaultAsync();
            }
            catch (Exception excepcion)
            {
                return null;
                _logger.LogError($"Error en {nameof(ObtenerNombreAsync)}: " + excepcion.Message);
            }            
        }
        public async Task<Proyecto> ObtenerConDetallesPorId(int id)
        {
            return await _dbSet.Include(proyecto => proyecto.UsuariosProyectos)                
                                    .ThenInclude(usuariosProyecto => usuariosProyecto.Usuario)
                                .Include(proyecto => proyecto.Incidencias)                                
                                .SingleOrDefaultAsync(c => c.Id == id && c.EstatusProyecto == EstatusProyecto.Activo);
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodos()
        {
            return await _dbSet
                .Where(u => u.EstatusProyecto == EstatusProyecto.Activo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodosConDetalle()
        {
            return await _dbSet
                .Include(proyecto => proyecto.UsuariosProyectos)
                .ThenInclude(usuariosProyecto => usuariosProyecto.Usuario)
                .Include(proyecto => proyecto.Incidencias)
                .Where(u => u.EstatusProyecto == EstatusProyecto.Activo)
                .ToListAsync();
        }

        public Task<Proyecto> ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
