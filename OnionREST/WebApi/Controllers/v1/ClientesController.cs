﻿using Application.Features.Clientes.Commands.CreateClienteCommand;
using Application.Features.Clientes.Commands.DeleteClienteCommand;
using Application.Features.Clientes.Commands.UpdateClienteCommand;
using Application.Features.Clientes.Queries.GetAllClientes;
using Application.Features.Clientes.Queries.GetClienteById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientesController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllClientesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllClientesQuery { 
                PageNumber = filter.PageNumber, PageSize = filter.PageSize,
                Nombre = filter.Nombre, Apellido = filter.Apellido  
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetClienteByIdQuery { Id = id }));
        }

        //Post api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Put api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        //Put api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClienteCommand { Id = id}));
        }
    }
}
