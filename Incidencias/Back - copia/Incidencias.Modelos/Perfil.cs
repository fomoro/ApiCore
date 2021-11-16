using System.Collections.Generic;

namespace Incidencias.Modelos
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
