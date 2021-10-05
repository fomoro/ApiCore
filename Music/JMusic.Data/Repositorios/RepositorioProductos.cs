using JMusic.Data.Contratos;
using JMusic.Models;
using JMusic.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMusic.Data.Repositorios
{

    public class ProductosRepositorio : IProductosRepositorio
    {
        private TiendaDbContext _contexto;

        public ProductosRepositorio(TiendaDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Actualizar(Producto producto)
        {
            var productoBd = await ObtenerProductoAsync(producto.Id);   //se agrega por que ahora es con dto
            productoBd.Nombre = producto.Nombre;    //se agrega por que ahora es con dto
            productoBd.Precio = producto.Precio;    //se agrega por que ahora es con dto

            //_contexto.Productos.Attach(producto);         //se quitan por que ahora es con dto
            //_contexto.Entry(producto).State = EntityState.Modified;   //se quitan por que ahora es con dto
            try
            {
                return await _contexto.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception excepcion)
            {
                return false;
            }
            return false;
        }

        public async Task<Producto> Agregar(Producto producto)
        {
            producto.Estatus = EstatusProducto.Activo;//se agrega porque la entiedad dto automaper viene sin esos campos
            producto.FechaRegistro = DateTime.UtcNow;//se agrega porque la entiedad dto automaper viene sin esos campos
            _contexto.Productos.Add(producto);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                return null;
            }

            return producto;
        }

        public async Task<bool> Eliminar(int id)
        {
            //Se realiza una eliminación suave, solamente inactivamos el producto

            var producto = await _contexto.Productos
                                .SingleOrDefaultAsync(c => c.Id == id);

            producto.Estatus = EstatusProducto.Inactivo;
            _contexto.Productos.Attach(producto);
            _contexto.Entry(producto).State = EntityState.Modified;

            try
            {
                return (await _contexto.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                ;
            }
            return false;

        }

        public async Task<Producto> ObtenerProductoAsync(int id)
        {
            return await _contexto.Productos
                               .SingleOrDefaultAsync(c => c.Id == id && c.Estatus == EstatusProducto.Activo);
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _contexto.Productos
                .Where(p => p.Estatus == EstatusProducto.Activo)
                .OrderBy(u => u.Nombre)
                .ToListAsync();
        }

        public async Task<(int totalRegistros, IEnumerable<Producto> registros)> ObtenerPaginasProductosAsync(int paginaActual, int registrosPorPagina)
        {            
            var totalRegistros = await _contexto.Productos
                .Where(u => u.Estatus == EstatusProducto.Activo)
                .CountAsync();

            var registrosPaginados = await _contexto.Productos
                                    .Where(u => u.Estatus == EstatusProducto.Activo)
                                    .Skip((paginaActual - 1) * registrosPorPagina)
                                    .Take(registrosPorPagina)
                                    .ToListAsync();

            return (totalRegistros, registrosPaginados);
        }
    }

}
