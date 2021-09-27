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
        }
    }
}
