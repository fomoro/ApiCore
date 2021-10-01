using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Incidencias.Modelos;
using Incidencias.WebApi.ViewModels;
using AutoMapper;

namespace Incidencias.WebApi.Mapper
{
    public class IncidenciasMapper: Profile
    {
        public IncidenciasMapper()
        {
            #region usuario
            this.CreateMap<Perfil, PerfilVM>().ReverseMap();

            this.CreateMap<Usuario, UsuarioRegistroVM>()
                .ForMember(u => u.Perfil, p => p.MapFrom(m => m.Perfil.Nombre))
                .ReverseMap()
                .ForMember(u => u.Perfil, p => p.Ignore());

            this.CreateMap<Usuario, UsuarioActualizacionVM>()
                .ReverseMap();

            this.CreateMap<Usuario, UsuarioListaVM>()
                .ForMember(u => u.Perfil, p => p.MapFrom(m => m.Perfil.Nombre))
                .ForMember(u => u.NombreCompleto, p => p.MapFrom(m => string.Format("{0} {1}", m.Nombre, m.Apellidos)))
                .ReverseMap();

            this.CreateMap<Usuario, PerfilUsuarioVM>().ReverseMap();

            this.CreateMap<Usuario, LoginVM>().ReverseMap();
            #endregion

            this.CreateMap<Proyecto, ProyectoVM>()
                .ReverseMap();

            this.CreateMap<Incidencia, IncidenciaVM>()                
                .ReverseMap();

            this.CreateMap<UsuariosProyectos, UsuariosProyectosVM>()
                .ForMember(u => u.NombreUsuario, p => p.MapFrom(u => u.Usuario.Username))
                .ReverseMap()
                .ForMember(u => u.Usuario, p => p.Ignore());


        }
    }
}
