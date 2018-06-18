using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    class CharlaModel
    {
        public string Titulo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
    }
}
