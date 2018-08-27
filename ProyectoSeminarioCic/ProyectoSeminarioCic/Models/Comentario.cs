using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int Id_publicacion { get; set; }
        public int Id_usuario { get; set; }

        public Comentario()
        {
            Texto = "";
            Id_publicacion = Id_usuario = 0;
        }
    }
}
