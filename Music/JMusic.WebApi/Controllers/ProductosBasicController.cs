using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMusic.Data.Contratos;
using JMusic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JMusik.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosBasicController : ControllerBase
    {
        private IProductosRepositorio _productosRepositorio;
        public ProductosBasicController(IProductosRepositorio productosRepositorio)
        {
            _productosRepositorio = productosRepositorio;
        }

        //// GET: api/Productos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            try
            {
                return await _productosRepositorio.ObtenerProductosAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _productosRepositorio.ObtenerProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        // POST: api/Productos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            try
            {
                var nuevoProducto = await _productosRepositorio.Agregar(producto);
                if (nuevoProducto == null)
                {
                    return BadRequest();
                }
                //CreatedAtAction devuelve en el header de postman https://localhost:44323/api/Productos?id=13
                return CreatedAtAction(nameof(Post), new { id = nuevoProducto.Id }, producto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Put(int id, [FromBody] Producto producto)
        {
            if (producto == null)
                return NotFound();

            var resultado = await _productosRepositorio.Actualizar(producto);
            if (!resultado)
                return BadRequest();

            return producto;

        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _productosRepositorio.Eliminar(id);
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
