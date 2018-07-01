using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Genero { get; set; }
        public byte [] Foto { get; set; }
        public string Ocupacion { get; set; }
        public string Rol { get; set; }

        //[OneToMany]
        public List<Publicacion> Publicaciones { get; set; }
        //[OneToMany]
        public List<Permiso_Usuario> Permiso_Usuarios { get; set; }
    }
}
