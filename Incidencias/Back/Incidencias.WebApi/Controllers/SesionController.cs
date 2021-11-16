using AutoMapper;
using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.Modelos;
using Incidencias.WebApi.Services;
using Incidencias.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Incidencias.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {

        private IUsuariosLogica _usuariosRepositorio;
        private IMapper _mapper;
        private TokenService _tokenService;

        public SesionController(IUsuariosLogica usuariosRepositorio, IMapper mapper, TokenService tokenService)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        //POST: api/sesion/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> PostLogin(LoginVM usuarioLogin)
        {
            //enviamos los datos de autiticacion 
            //retornamos si el usuario tiene ok en todo
            var datosLoginUsuario = _mapper.Map<Usuario>(usuarioLogin);

            var resultadoValidacion = await _usuariosRepositorio.ValidarDatosLogin(datosLoginUsuario);
            if (!resultadoValidacion.resultado)
            {
                return BadRequest("Usuario/Contraseña Inválidos.");
            }

            //generamos el token
            return _tokenService.GenerarToken(resultadoValidacion.usuario);
        }
    }
}