using SQLite.Net.Attributes;
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
        public DateTime Anio { get; set; }
        public string ImagenPath { get; set; }
        public byte[] ImagenArray { get; set; }
        public string Icon { get; set; }


        public List<Boleta> Boleta { get; set; }
        public List<Evento> Evento { get; set; }

        public Seminario()
        {
            Boleta = new List<Boleta>();
            Evento = new List<Evento>();
        }

    }

}
