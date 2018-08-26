using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
   public class Comment
    {
        public Models.Usuario User { get; set; }

        public Models.Comentario Comments { get; set; }

        public Comment(Models.Usuario user, Models.Comentario comments)
        {
            User = user;
            Comments = comments;
        }

    }
}
