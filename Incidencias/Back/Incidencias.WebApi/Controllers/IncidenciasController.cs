using AutoMapper;
using Incidencias.Interfaces.LogicaDeNegocio;
using Incidencias.Modelos;
using Incidencias.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.WebApi.Controllers
{
    [Authorize(Roles = "Tester")]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {

        private IIncidenciasLogica _incidenciasRepositorio;
        private readonly ILogger<IncidenciasController> _logger;
        private readonly IMapper _mapper;

        public IncidenciasController(IIncidenciasLogica _incidenciasRepositorio, ILogger<IncidenciasController> logger, IMapper mapper)
        {
            this._incidenciasRepositorio = _incidenciasRepositorio;
            this._logger = logger;
            this._mapper = mapper;
        }

        //// GET: api/usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<IncidenciaVM>>> Get()
        {
            try
            {
                var incidencia = await _incidenciasRepositorio.ObtenerTodos();
                return _mapper.Map<List<IncidenciaVM>>(incidencia);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IncidenciaVM>> Get(int id)
        {            
            try
            {
                var incidencia = await _incidenciasRepositorio.ObtenerPorId(id);
                if (incidencia == null)
                {
                    return NotFound();
                }
                return _mapper.Map<IncidenciaVM>(incidencia);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Get)}: " + ex.Message);
                return BadRequest();
            }
        }

        // POST: api/usuarios
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioListaVM>> Post(IncidenciaVM incidenciaVM)
        {
            try
            {
                var incidencia = _mapper.Map<Incidencia>(incidenciaVM);

                var nuevaIncidencia = await _incidenciasRepositorio.Agregar(incidencia);
                if (nuevaIncidencia == null)
                {
                    return BadRequest();
                }

                var nuevoIncidenciaVM = _mapper.Map<IncidenciaVM>(nuevaIncidencia);
                return CreatedAtAction(nameof(Post), new { id = nuevoIncidenciaVM.Id }, nuevoIncidenciaVM);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Post)}: " + ex.Message);
                return BadRequest();
            }
        }

        // PUT: api/usuarios/5
        [Authorize(Roles = "Desarrollador, Tester")]
        //[Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaVM>> Put(int id, [FromBody] IncidenciaVM incidenciaVM)
        {
            try
            {
                if (incidenciaVM == null)
                    return NotFound();

                var incidencia = _mapper.Map<Incidencia>(incidenciaVM);
                var resultado = await _incidenciasRepositorio.Actualizar(incidencia);
                if (!resultado)
                    return BadRequest();

                return _mapper.Map<IncidenciaVM>(incidencia);

            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Put)}: " + excepcion.Message);
                return BadRequest();
            }

   
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _incidenciasRepositorio.Eliminar(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Delete)}: " + excepcion.Message);
                return BadRequest();
            }
        }         

    }
}