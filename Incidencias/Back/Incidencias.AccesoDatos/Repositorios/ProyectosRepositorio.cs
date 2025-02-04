﻿using Incidencias.InterfacesAccesoDatos;
using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Incidencias.AccesoDatos.Repositorios
{
    public class ProyectosRepositorio : IProyectosRepositorio
    {
        private readonly Contexto _contexto;
        private readonly ILogger<PerfilesRepositorio> _logger;
        private DbSet<Proyecto> _dbSet;

        public ProyectosRepositorio(Contexto contexto, ILogger<PerfilesRepositorio> logger)
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

        public async Task<Proyecto> ObtenerAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(c => c.Id == id
                                && c.EstatusProyecto == EstatusProyecto.Activo);
        }

        public async Task<Proyecto> ObtenerNombreAsync(string nombre)
        {
            try
            {
                return await _dbSet.Where(c => c.Nombre == nombre && c.EstatusProyecto == EstatusProyecto.Activo).FirstOrDefaultAsync();
            }
            catch (Exception excepcion)
            {
                return null;
                _logger.LogError($"Error en {nameof(ObtenerNombreAsync)}: " + excepcion.Message);
            }
        }

        public async Task<IEnumerable<Proyecto>> ObtenerProyectosPorUsuario(int idUsuario)
        {
            try
            {
                var idsProyectos = await _contexto.Set<UsuariosProyectos>()
                .Where(c => c.UsuarioId == idUsuario).Select(p => p.ProyectoId ).ToListAsync();

                var proyectosFiltrados = await _dbSet
                    .Where(allP => idsProyectos.Contains(allP.Id))
                    .ToListAsync();

                return proyectosFiltrados;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }


        public async Task<Proyecto> ObtenerConIncidenciasPorId(int id)
        {
            return await _dbSet.Include(proyecto => proyecto.UsuariosProyectos)
                                    .ThenInclude(usuariosProyecto => usuariosProyecto.Usuario)
                                .Include(proyecto => proyecto.Incidencias)
                                .SingleOrDefaultAsync(c => c.Id == id && c.EstatusProyecto == EstatusProyecto.Activo);
        }

        public async Task<Proyecto> ObtenerConTareasPorId(int id)
        {
            var resultado = await _dbSet.Include(proyecto => proyecto.UsuariosProyectos)
                                    .ThenInclude(usuariosProyecto => usuariosProyecto.Usuario)
                                .Include(proyecto => proyecto.Incidencias)
                                .Include(proyecto => proyecto.Tareas)
                                .SingleOrDefaultAsync(c => c.Id == id && c.EstatusProyecto == EstatusProyecto.Activo);

            return resultado;
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodosAsync()
        {
            return await _dbSet
                .Where(u => u.EstatusProyecto == EstatusProyecto.Activo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodosConDetallesAsync()
        {
            return await _dbSet
                .Include(proyecto => proyecto.UsuariosProyectos)
                .ThenInclude(usuariosProyecto => usuariosProyecto.Usuario)
                .Include(proyecto => proyecto.Incidencias)
                .Where(u => u.EstatusProyecto == EstatusProyecto.Activo)
                .ToListAsync();
        }

    }
}
