using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Comentario
    {
        public int Id_comentario { get; set; }
        public string Texto { get; set; }
        public int Id_publicacion { get; set; }


    }
}
