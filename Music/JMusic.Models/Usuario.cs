﻿using JMusic.Models.Enum;
using System;
using System.Collections.Generic;

#nullable disable

namespace JMusic.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ordenes = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public EstatusUsuario Estatus { get; set; }
        public int PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
