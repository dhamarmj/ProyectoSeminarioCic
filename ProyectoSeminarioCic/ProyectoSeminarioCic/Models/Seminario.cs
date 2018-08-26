using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Seminario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string ImagenPath { get; set; }
        public byte[] ImagenArray { get; set; }


        public List<Boleta> Boleta { get; set; }
        public List<Evento> Evento { get; set; }

        public Seminario()
        {
            FechaFinal = FechaInicio = new DateTime();
            Boleta = new List<Boleta>();
            Evento = new List<Evento>();
            Titulo = Descripcion = ImagenPath = string.Empty;
        }

    }

}
