using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
   public class Publicacion
    {
       public int Id { get; set; }
        public string imagenPerfil { get; set; }
        public string nombreUsuario { get; set; }
        public string imagenPublicacion { get; set; }
        public string caption { get; set; }
        public string numKaip { get; set; }
        public string numComent { get; set; }

        public List<Comentario> comments { get; set; }

    }
}
