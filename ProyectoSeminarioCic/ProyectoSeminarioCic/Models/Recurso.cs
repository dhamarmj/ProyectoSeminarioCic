using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
   
    public class Recurso
    {
        
        public int Id_recurso { get; set; }
        public string Titulo { get; set; }
        public string Recursos { get; set; }

        public Recurso()
        {
            Titulo = Recursos = string.Empty;
        }
    }
}
