using Incidencias.InterfacesAccesoDatos;
using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.LogicaDeNegocio
{
    public class LogicaDeProyectos : IProyectosLogica
    {
        private const string null_Proyecto = "Proyecto";

        IProyectosRepositorio _repository;
        IUsuariosRepositorio _repositorioUsuarios;

        public LogicaDeProyectos(IProyectosRepositorio repository, IUsuariosRepositorio repositorioUsuarios)
        {
            _repository = repository;
            _repositorioUsuarios = repositorioUsuarios;
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

        public async Task<IEnumerable<Proyecto>> GetProyectosPorUsuario(int idUsuario)
        {
            var proyectos = await _repository.ObtenerProyectosPorUsuario(idUsuario);                

            return proyectos;
        }
       
        public async Task<decimal> GetCostoPorProyecto(int idProyecto)
        {
            try
            {
               
                var proyecto = await _repository.ObtenerConTareasPorId(idProyecto);
                var TotalCostoTareas = proyecto.Tareas.Select(x => (x.Duracion * x.Costo)).Sum();
                
                decimal TotalCostoIncidencias = 0;
                foreach (var incidencia in proyecto.Incidencias.Where(x => x.EstatusIncidencia == Modelos.Enum.EstatusIncidencia.Resuelto))
                {
                    var desarrollador = await _repositorioUsuarios.ObtenerAsync(incidencia.DesarrolladorId);
                    var tester = await _repositorioUsuarios.ObtenerAsync(incidencia.TesterId);

                    TotalCostoIncidencias += (incidencia.Duracion * desarrollador.CostoHora) + (incidencia.Duracion * tester.CostoHora);                 
                }

                return TotalCostoIncidencias + TotalCostoTareas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetDuracionPorProyecto(int idProyecto)
        {
            try
            {

                var proyecto = await _repository.ObtenerConTareasPorId(idProyecto);
                var TotalCostoTareas = proyecto.Tareas.Select(x => (x.Duracion)).Sum();
                var TotalCostoIncidencias = proyecto.Incidencias.Select(x => (x.Duracion)).Sum();
                
                return TotalCostoIncidencias + TotalCostoTareas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Proyecto> ObtenerConIncidenciasPorId(int id)
        {
            return await _repository.ObtenerConIncidenciasPorId(id);
        }

        public async Task<Proyecto> ObtenerConTareasPorId(int id)
        {
            return await _repository.ObtenerConTareasPorId(id);
        }

        public async Task<Proyecto> ObtenerPorId(int id)
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

        public async Task<Proyecto> ObtenerPorNombre(string nombre)
        {
            return await _repository.ObtenerNombreAsync(nombre);
        }

        public async Task<IEnumerable<Proyecto>> ObtenerTodos()
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

        public async Task<IEnumerable<Proyecto>> ObtenerTodosConDetalle()
        {
            return await _repository.ObtenerTodosConDetallesAsync();
        }
        
    }
}