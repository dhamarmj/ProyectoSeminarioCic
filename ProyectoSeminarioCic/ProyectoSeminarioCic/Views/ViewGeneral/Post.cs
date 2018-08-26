using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
   public class Post
    {
        public Models.Publicacion Publicacion { get; set; }
        public Models.Usuario User { get; set; }
       public int Comentario { get; set; }

        public Post(Models.Publicacion publicacion, Models.Usuario user, int count)
        {
            Publicacion = publicacion;
            User = user;
            Comentario = count;
        }
    }
}
