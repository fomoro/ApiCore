using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.Modelos.Enum;
using Incidencias.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {

        private IIncidenciasLogica _incidenciasRepositorio;
        private IProyectosLogica _proyectosRepositorio;
        private readonly ILogger<ReportesController> _logger;

        public ReportesController(IIncidenciasLogica _incidenciasRepositorio, ILogger<ReportesController> logger, IProyectosLogica _proyectosRepositorio)
        {
            this._incidenciasRepositorio = _incidenciasRepositorio;
            this._proyectosRepositorio = _proyectosRepositorio;
            this._logger = logger;
        }

        [HttpGet("IncidenciasPorProyecto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> IncidenciasPorProyecto()
        {
            try
            {
                var proyectos = await _proyectosRepositorio.ObtenerTodosConDetalle();
                var resultado = proyectos.Select(x => new
                {
                    Nombre = x.Nombre,
                    CantidadIncidencias = x.Incidencias.Count()
                }).ToList();


                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(IncidenciasPorProyecto)}: " + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("IncidenciasResueltasDesarrolador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> IncidenciasResueltasDesarrolador()
        {
            try
            {
                var incidencias = await _incidenciasRepositorio.ObtenerTodos();
                var resultado = incidencias
                    .Where(x => x.EstatusIncidencia == EstatusIncidencia.Resuelto)
                    .GroupBy(x => x.DesarrolladorId)
                    .Select(y => new
                    {
                        DesarrolladorId = y.Key,
                        BugsResueltos = y.Count()
                    });

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(IncidenciasResueltasDesarrolador)}: " + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("IncidenciasPorTester/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> IncidenciasPorTester(int id, [FromBody] IncidenciaFilterVM incidenciaVM)
        {
            try
            {            
                var incidencias = await _incidenciasRepositorio.ObtenerTodos();
                var resultado = from i in incidencias
                        where (i.TesterId == id)
                        && (i.Id == id || incidenciaVM.Id == null)
                        && (i.ProyectoId == incidenciaVM.ProyectoId || incidenciaVM.ProyectoId == null)
                        && (i.Nombre == incidenciaVM.Nombre || incidenciaVM.Nombre == null)
                        && (i.EstatusIncidencia == incidenciaVM.EstatusIncidencia || incidenciaVM.EstatusIncidencia == null)
                        select new
                        {
                            i.Id,
                            i.Proyecto.Nombre,
                            i.EstatusIncidencia                            
                        };
                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(IncidenciasPorProyecto)}: " + ex.Message);
                return BadRequest();
            }
        }

    }
}