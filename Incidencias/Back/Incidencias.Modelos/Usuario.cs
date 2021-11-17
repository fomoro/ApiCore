using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incidencias.Modelos.Enum;

namespace Incidencias.Modelos
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuariosProyectos = new HashSet<UsuariosProyectos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal CostoHora { get; set; }
        public EstatusUsuario Estatus { get; set; }        
        
        
        public int PerfilId { get; set; }        
        public Perfil Perfil { get; set; }

        public ICollection<UsuariosProyectos> UsuariosProyectos { get; set; }
    }
}
