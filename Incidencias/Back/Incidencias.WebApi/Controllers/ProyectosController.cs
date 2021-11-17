using AutoMapper;
using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.Modelos;
using Incidencias.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private IProyectosLogica _proyectosRepositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<ProyectosController> _logger;

        public ProyectosController(IProyectosLogica proyectosRepositorio, ILogger<ProyectosController> logger, IMapper mapper)
        {
            this._proyectosRepositorio = proyectosRepositorio;
            this._logger = logger;
            this._mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProyectoVM>>> Get()
        {
            try
            {
                var proyectos = await _proyectosRepositorio.ObtenerTodos();
                return _mapper.Map<List<ProyectoVM>>(proyectos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }
        }


        //// GET: api/proyectos/incidencias
        [HttpGet]
        [Route("incidencias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProyectoVM>>> GetproyectosConDetalle()
        {
            try
            {
                var proyectos = await _proyectosRepositorio.ObtenerTodosConDetalle();
                var result = _mapper.Map<List<ProyectoVM>>(proyectos);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }
        }

        // GET: api/proyectos/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProyectoVM>> Get(int id)
        {
            try
            {
                var proyecto = await _proyectosRepositorio.ObtenerPorId(id);
                if (proyecto == null)
                {
                    return NotFound();
                }
                return _mapper.Map<ProyectoVM>(proyecto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }
            
        }

        
        [HttpGet("usuario/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProyectoVM>> GetProyectosPorUsuario(int idUsuario)
        {
            try
            {
                var proyectos = await _proyectosRepositorio.GetProyectosPorUsuario(idUsuario);
                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }

        }

        [HttpGet("{idProyecto}/costoPorProyecto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<double>> GetCostoPorProyecto(int idProyecto)
        {
            try
            {
                var proyectos = await _proyectosRepositorio.GetCostoPorProyecto(idProyecto);
                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }

        }
        

        [HttpGet("{id}/incidencias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProyectoVM>> ObtenerConIncidenciasPorId(int id)
        {
            var proyecto = await _proyectosRepositorio.ObtenerConIncidenciasPorId(id);            
            if (proyecto == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProyectoVM>(proyecto);
        }

        [HttpGet("{id}/tareas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProyectoVM>> GetproyectoConTareas(int id)
        {
            var proyecto = await _proyectosRepositorio.ObtenerConTareasPorId(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProyectoVM>(proyecto);
        }

        // POST: api/proyectos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProyectoVM>> Post(ProyectoVM proyectoVM)
        {
            try
            {
                var proyecto = _mapper.Map<Proyecto>(proyectoVM);

                var nuevaproyecto = await _proyectosRepositorio.Agregar(proyecto);
                if (nuevaproyecto == null)
                {
                    return BadRequest();
                }

                var nuevaProyecto = _mapper.Map<ProyectoVM>(nuevaproyecto);
                return CreatedAtAction(nameof(Post), new { id = nuevaProyecto.Id }, nuevaProyecto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/proyectos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _proyectosRepositorio.Eliminar(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {
                return BadRequest();
            }
        }

    }
}