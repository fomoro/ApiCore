using Incidencias.InterfacesAccesoDatos;
using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.LogicaDeNegocio
{
    public class LogicaDeUsuario : IUsuariosLogica
    {
        private const string null_Usuario = "Usuario";

        IUsuariosRepositorio _repositorio;

        public LogicaDeUsuario(IUsuariosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        
        public async Task<bool> Actualizar(Usuario entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_Usuario);
            }
            return await _repositorio.Actualizar(entity);
        }

        public async Task<Usuario> Agregar(Usuario entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_Usuario);
            }
            await _repositorio.Agregar(entity);
            return entity;
        }

        public async Task<bool> CambiarContrasena(Usuario usuario)
        {
            return await _repositorio.CambiarContrasena(usuario);
        }

        public async Task<bool> CambiarPerfil(Usuario usuario)
        {
            return await _repositorio.CambiarPerfil(usuario);
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await _repositorio.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            try
            {
                return await _repositorio.ObtenerAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            try
            {
                return await _repositorio.ObtenerTodosAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ValidarContrasena(Usuario usuario)
        {
            return await _repositorio.ValidarContrasena(usuario);
        }

        public async Task<(bool resultado, Usuario usuario)> ValidarDatosLogin(Usuario datosLoginUsuario)
        {
            return await _repositorio.ValidarDatosLogin(datosLoginUsuario);
        }
    }
}