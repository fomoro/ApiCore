﻿using System.Threading.Tasks;
using AutoMapper;
using JMusic.Data.Contratos;
using JMusic.Dtos;
using JMusic.Models;
using JMusic.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMusic.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {

        private IUsuariosRepositorio _usuariosRepositorio;
        private IMapper _mapper;
        private TokenService _tokenService;

        public SesionController(IUsuariosRepositorio usuariosRepositorio, IMapper mapper, TokenService tokenService)
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
        public async Task<ActionResult<string>> PostLogin(LoginModelDto usuarioLogin)
        {
            var datosLoginUsuario = _mapper.Map<Usuario>(usuarioLogin);

            var resultadoValidacion = await _usuariosRepositorio.ValidarDatosLogin(datosLoginUsuario);
            if (!resultadoValidacion.resultado)
            {
                return BadRequest("Usuario/Contraseña Inválidos.");
            }
            return _tokenService.GenerarToken(resultadoValidacion.usuario);
        }
    }
}