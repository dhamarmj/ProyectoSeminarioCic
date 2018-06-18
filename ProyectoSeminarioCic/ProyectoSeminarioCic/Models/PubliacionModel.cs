using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    class PubliacionModel
    {
        public string nombreUsuario { get; set; }
        public string imagenPerfil { get; set; }
        public string imagenPublicacion { get; set; }
        public string numKaip { get; set; }
        public string numComent { get; set; }
        public List<ComentarioPublicacion> comentarioModel { get; set; }
    }
}
