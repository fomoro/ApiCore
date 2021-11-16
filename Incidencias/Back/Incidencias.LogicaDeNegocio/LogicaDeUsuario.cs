using Incidencias.InterfacesAccesoDatos;
using Incidencias.InterfacesLogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.LogicaDeNegocio
{
    public class LogicaDeUsuario : IUsuariosLogica
    {
        private const string null_perfil = "Usuario";

        IUsuariosRepositorio _repository;

        public LogicaDeUsuario(IUsuariosRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<bool> Actualizar(Usuario entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_perfil);
            }
            return await _repository.Actualizar(entity);
        }

        public async Task<Usuario> Agregar(Usuario entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(null_perfil);
            }
            await _repository.Agregar(entity);
            return entity;
        }

        public async Task<bool> CambiarContrasena(Usuario usuario)
        {
            return await _repository.CambiarContrasena(usuario);
        }

        public async Task<bool> CambiarPerfil(Usuario usuario)
        {
            return await _repository.CambiarPerfil(usuario);
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await _repository.Eliminar(id);
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
                return await _repository.ObtenerPorId(id);
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
                return await _repository.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ValidarContrasena(Usuario usuario)
        {
            return await _repository.ValidarContrasena(usuario);
        }

        public async Task<(bool resultado, Usuario usuario)> ValidarDatosLogin(Usuario datosLoginUsuario)
        {
            return await _repository.ValidarDatosLogin(datosLoginUsuario);
        }
    }
}