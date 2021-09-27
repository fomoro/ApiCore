using AutoMapper;
using JMusic.Dtos;
using JMusic.Models;

namespace JMusik.WebApi.Profiles
{
    public class JMusicProfile:Profile
    {
        public JMusicProfile()
        {
            //ReverseMap hace la conversion en doble via
            this.CreateMap<Producto, ProductoDto>().ReverseMap();           
            this.CreateMap<Perfil, PerfilDto>().ReverseMap();
            this.CreateMap<Orden, OrdenDto>()
              .ForMember(u => u.Usuario, p => p.MapFrom(m => m.Usuario.Username))
              .ReverseMap()
              .ForMember(u => u.Usuario, p => p.Ignore());//que no cree la entiedad usuario

            this.CreateMap<DetalleOrden, DetalleOrdenDto>()
                .ForMember(u => u.Producto, p => p.MapFrom(u => u.Producto.Nombre))
                .ReverseMap()
                .ForMember(u => u.Producto, p => p.Ignore());//que no cree la entiedad producto
        }
    }
}
