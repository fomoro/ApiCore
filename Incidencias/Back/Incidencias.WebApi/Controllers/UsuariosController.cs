using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Incidencias.Interfaces.AccesoDatos;
using Incidencias.Modelos;
using Incidencias.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Incidencias.WebApi.Controllers
{
    [Authorize(Roles = "Desarrollador")]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private IUsuariosRepositorio _usuariosRepositorio;
        private readonly ILogger<UsuariosController> _logger;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuariosRepositorio _usuariosRepositorio, ILogger<UsuariosController> logger, IMapper mapper)
        {
            this._usuariosRepositorio = _usuariosRepositorio;
            this._logger = logger;
            this._mapper = mapper;
        }

        //// GET: api/usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UsuarioRegistroVM>>> Get()
        {
            try
            {
                var usuarios = await _usuariosRepositorio.ObtenerTodosAsync();
                return _mapper.Map<List<UsuarioRegistroVM>>(usuarios);
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
        public async Task<ActionResult<UsuarioRegistroVM>> Get(int id)
        {            
            try
            {
                var usuario = await _usuariosRepositorio.ObtenerAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return _mapper.Map<UsuarioRegistroVM>(usuario);
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
        public async Task<ActionResult<UsuarioListaVM>> Post(UsuarioRegistroVM usuarioRegistroViewModels)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioRegistroViewModels);

                var nuevoUsuario = await _usuariosRepositorio.Agregar(usuario);
                if (nuevoUsuario == null)
                {
                    return BadRequest();
                }

                var nuevoUsuarioDto = _mapper.Map<UsuarioRegistroVM>(nuevoUsuario);
                return CreatedAtAction(nameof(Post), new { id = nuevoUsuarioDto.Id }, nuevoUsuarioDto);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Post)}: " + ex.Message);
                return BadRequest();
            }
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioListaVM>> Put(int id, [FromBody] UsuarioActualizacionVM usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                var usuario = _mapper.Map<Usuario>(usuarioDto);
                var resultado = await _usuariosRepositorio.Actualizar(usuario);
                if (!resultado)
                    return BadRequest();

                return _mapper.Map<UsuarioListaVM>(usuario);

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
                var resultado = await _usuariosRepositorio.Eliminar(id);
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

        // POST: api/usuarios/cambiarcontrasena
        [HttpPost]
        [Route("cambiarcontrasena")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCambiarContrasena(LoginVM usuarioContrasenaDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioContrasenaDto);
                var resultado = await _usuariosRepositorio.CambiarContrasena(usuario);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();                

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Post)}: " + ex.Message);
                return BadRequest();
            }
        }

        // POST: api/usuarios/cambiarperfil
        [HttpPost]
        [Route("cambiarperfil")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCambiarPerfil(PerfilUsuarioVM perfilUsuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(perfilUsuarioDto);

                var resultado = await _usuariosRepositorio.CambiarPerfil(usuario);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Post)}: " + ex.Message);
                return BadRequest();
            }
        }

        // POST: api/usuarios/validarusuario
        [HttpPost]
        [Route("validarusuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioRegistroVM>> PostValidarUsuario(LoginVM usuarioContrasenaDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioContrasenaDto);

                var resultado = await _usuariosRepositorio.ValidarContrasena(usuario);
                if (!resultado)
                {
                    return BadRequest();
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}