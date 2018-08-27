using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
   
    public class Publicacion
    {
        public int Id { get; set; }
        public string Pie_imagen { get; set; }
        public string ImagenPath { get; set; }
        public int Kaip { get; set; }
        public int Id_usuario { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public byte[] ImagenArray { get; set; }

        public Publicacion()
        {
            Comentarios = new List<Comentario>();
            Pie_imagen = ImagenPath = string.Empty;
            Kaip = Id_usuario = 0;
        }
    }
}
