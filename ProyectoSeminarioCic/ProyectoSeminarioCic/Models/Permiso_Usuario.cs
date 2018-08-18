using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
   
    public class Permiso_Usuario
    {
      
        public int Id_permiso_usuario { get; set; }
        public Usuario Usuario { get; set; }
        public Permiso Permiso { get; set; }
    }
}
    
    
    