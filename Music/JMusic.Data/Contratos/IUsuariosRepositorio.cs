﻿using JMusic.Models;
using System.Threading.Tasks;

namespace JMusic.Data.Contratos
{
    public interface IUsuariosRepositorio : IRepositorioGenerico<Usuario>
    {
        Task<bool> CambiarContrasena(Usuario usuario);
        Task<bool> CambiarPerfil(Usuario usuario);
        Task<bool> ValidarContrasena(Usuario usuario);
        Task<(bool resultado, Usuario usuario)> ValidarDatosLogin(Usuario datosLoginUsuario);
    }
}
