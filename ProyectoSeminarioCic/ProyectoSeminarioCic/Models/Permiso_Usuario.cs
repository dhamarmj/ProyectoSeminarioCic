using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Permiso_Usuario")]
    public class Permiso_Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_permiso_usuario { get; set; }
        public Usuario Usuario { get; set; }
        public Permiso Permiso { get; set; }
    }
}
    
    
    